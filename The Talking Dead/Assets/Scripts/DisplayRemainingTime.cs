using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRemainingTime : MonoBehaviour {

    TextMesh tm;

    private double totalTime = 120.00;
    private double startTime;

    private double timeLeft;

    // Use this for initialization
    void Start()
    {
        tm = GetComponent<TextMesh>();
        startTime = Time.time;
        timeLeft = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        double timeElapsed = Time.time - startTime;
        if(timeElapsed < totalTime)
        {
            timeLeft = totalTime - timeElapsed;
            if (tm.text != timeLeft.ToString("F0"))
            {
                tm.text = timeLeft.ToString("F0");
            }
        }
        else
        {
            //game is over!
            GameManager gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
            gameManager.TimeUp();
        }
        
    }

    public double GetRemainingTime()
    {
        return timeLeft;
    }
}
