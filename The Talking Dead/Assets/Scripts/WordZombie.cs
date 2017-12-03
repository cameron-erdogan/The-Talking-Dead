using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieInfo
{
    public string word;
    public string user;

    public ZombieInfo(string word, string user)
    {
        this.word = word;
        this.user = user;
    }
}

public class WordZombie : MonoBehaviour, System.IEquatable<WordZombie> {

	public TextMeshPro wordLabel;

    private ZombieInfo info;

    public void SetInfo(ZombieInfo info)
    {
        this.info = info;
        wordLabel.text = info.word;
    }

	public string GetWord(){
        return info.word;
	}

	public bool Equals(WordZombie otherZombie){
		print ("comparing jawns");
		return GetWord ().Equals (otherZombie.GetWord ());
	}
}
