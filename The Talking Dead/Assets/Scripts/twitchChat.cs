using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;

////make a list that loads in from dictionary text file
//public static class checkDictionary 
//{
//	//function to read from dictionary.txt
//	//check chat input with dictionary
//	TextAsset dictionary = Resources.Load("MyText/words.txt") as TextAsset;
//
//}	

public class twitchChat : MonoBehaviour
{
	public static twitchChat inst;
    public string oath;
    public string username;
    public List<string> channels;

	//counter for upvotes and downvotes
	public static int UpvoteDownvote;

    private string address = "irc.chat.twitch.tv";
    private int port = 6667;
    private Queue<string> outputQueue;
    private Queue<string> inputQueue;
    private string input;
    private string output;
    private bool StopThreads = false;
    private System.Threading.Thread procIn, procOut;
    private System.Net.Sockets.NetworkStream netStream;
    private System.Threading.ReaderWriterLock outlock, inlock;
    private System.IO.StreamReader read;
    private System.IO.StreamWriter write;
    private string buffer;
    private System.Net.Sockets.TcpClient server;

    // Use this for initialization
    void Start()
    {
        inst = this;
        server = new System.Net.Sockets.TcpClient();
        server.Connect(address, port);
        if (!server.Connected)
        {
            Debug.Log("Failed to connect!");
            return;
        }
        Debug.Log("Connected");
        inputQueue = new Queue<string>();
        outputQueue = new Queue<string>();
        netStream = server.GetStream();
        read = new System.IO.StreamReader(netStream);
        write = new System.IO.StreamWriter(netStream);
        outlock = new System.Threading.ReaderWriterLock();
        inlock = new System.Threading.ReaderWriterLock();

        write.WriteLine("PASS " + oath);
        write.WriteLine("NICK " + username.ToLower());

        write.Flush();

        procIn = new System.Threading.Thread(() => IRCInputProcedure());
        procIn.Start();
        procOut = new System.Threading.Thread(() => IRCOutputProcedure());
        procOut.Start();

        Debug.Log("We're in");

    }

    private void IRCInputProcedure()
    {
        while (!StopThreads)
        {
            if (!netStream.DataAvailable)
            {
                System.Threading.Thread.Sleep(100);
                continue;
            }
            buffer = read.ReadLine();
            input = buffer;

            if (buffer.Split(' ')[1] == "001")
            {
                foreach (string channel in channels)
                {
                    sendMessage("JOIN #" + channel.ToLower());
                }

                sendMessage("CAP REQ :twitch.tv/commands");
                sendMessage("CAP REQ :twitch.tv/tags");
            }
            else if (input.Split(' ')[0] == "PING")
            {
                input.Replace("PING", "PONG");
                outlock.AcquireWriterLock(100);
                outputQueue.Enqueue(input);
                outlock.ReleaseWriterLock();
            }
            else
            {
                inlock.AcquireWriterLock(100);
                inputQueue.Enqueue(input);
                inlock.ReleaseWriterLock();
            }
        }
    }

    private void IRCOutputProcedure()
    {
        while (!StopThreads)
        {
            if (outputQueue.Count < 1)
            {
                System.Threading.Thread.Sleep(100);
                continue;
            }
            outlock.AcquireWriterLock(100);
            output = outputQueue.Dequeue();
            outlock.ReleaseWriterLock();
            write.WriteLine(output);
            write.Flush();
            Debug.Log("OUT " + output);
            System.Threading.Thread.Sleep(1000);
        }
    }

    private void sendMessage(string message)
    {
        outlock.AcquireWriterLock(100);
        outputQueue.Enqueue(message);
        outlock.ReleaseWriterLock();
    }

    public void sendMessage(string channelName, string message)
    {
        outlock.AcquireWriterLock(100);
        outputQueue.Enqueue("PRIVMSG #" + channelName + " :" + message);
        outlock.ReleaseWriterLock();
    }

    public void sendMessage(int channelIndex, string message)
    {
        sendMessage(channels[channelIndex], message);
    }

    void OnDestroy()
    {
        StopThreads = true;
        server.Close();
    }

    string getUser(string line)
    {
        try
        {
            string[] split1 = line.Split('!');
            return split1[1].Split('@')[0];
        }
        catch
        {
            return "";
        }
    }

    string getMessage(string line)
    {
        try
        {
			string[] split1 = line.Split('#');
            string[] split2 = split1[1].Split(':');
            string msg = "";
            for (int i = 1; i < split2.Length; ++i)
            {
                msg += split2[i];
            }
            return msg;
        }
        catch
        {
            return "";
        }
    }

    string getChannelName(string line)
    {
        try
        {
            string[] split1 = line.Split('!');
            string[] split2 = split1[1].Split(':');
            return split2[0].Split('#')[1];
        }
        catch
        {
            return "";
        }
    }

    string getMod(string line)
    {
        try
        {
            int index = line.IndexOf("mod=");
            return line[index + 4].ToString();
        }
        catch
        {
            return "";
        }
    }

    string getSub(string line)
    {
        try
        {
            int index = line.IndexOf("subscriber=");
            return line[index + 11].ToString();
        }
        catch
        {
            return "";
        }
    }

    string getTurbo(string line)
    {
        try
        {
            int index = line.IndexOf("turbo=");
            return line[index + 6].ToString();
        }
        catch
        {
            return "";
        }
    }

    int getOwner(string line)
    {
        try
        {
            int index = line.IndexOf("room-id=");
            string roomid = "";
            for (int i = index + 8; line[i] != ';'; ++i)
            {
                roomid += line[i];
            }
            index = line.IndexOf("user-id=");
            string userid = "";
            for (int i = index + 8; line[i] != ';'; ++i)
            {
                userid += line[i];
            }
            if (userid == roomid)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch
        {
            return 0;
        }
    }

    string getBannedChannelName(string line)
    {
        try
        {
            string[] split1 = line.Split(':');
            return split1[1].Split('#')[1];
        }
        catch
        {
            return "";
        }
    }

    string getBannedUser(string line)
    {
        try
        {
            return line.Split(':')[2];
        }
        catch
        {
            return "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        inlock.AcquireWriterLock(100);
        while (inputQueue.Count > 0)
        {
            string line = inputQueue.Dequeue();
			//ADD TEXTPARSING HERE
			string msg = getMessage(line);

			if(msg.Length < 7) 
			{
				continue;
			}
			if (msg.Substring (0, 5).ToLower () == "!word") 
			{

				string actualWord = msg.Substring (6);
				Debug.LogError (actualWord);

				TextAsset loadDictionary = Resources.Load ("words", typeof(TextAsset)) as TextAsset;
				var dictionary = Encoding.ASCII.GetString (loadDictionary.bytes);

				if (dictionary.Contains (actualWord)) 
				{
					Debug.Log (actualWord);
					GameManager gameManager = GameObject.FindGameObjectWithTag ("Game Manager").GetComponent<GameManager> ();
					gameManager.AddWordToWordQueue (actualWord);
				}
			} 
			else if (msg.Substring (0, 5).ToLower () == "!vote") 
			{
				string vote = msg.Substring (6);
				Debug.LogError (vote);

				if (vote == "up") 
				{
					//set vote to 1
					UpvoteDownvote = 1;
				}
				else if (vote == "down") 
				{
					UpvoteDownvote = 0;
				} 
				Debug.Log (UpvoteDownvote);
			}

        }
        inlock.ReleaseWriterLock();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sendMessage("twtwitchtest","test2");
        }
    }
}
