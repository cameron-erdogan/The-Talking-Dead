using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRemainingTime : MonoBehaviour {

    TextMesh tm;

    private double totalTime = 120.00;
    private double startTime;

    // Use this for initialization
    void Start()
    {
        tm = GetComponent<TextMesh>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        double timeElapsed = Time.time - startTime;
        if(timeElapsed < totalTime)
        {
            double timeLeft = totalTime - timeElapsed;
            if (tm.text != timeLeft.ToString("F"))
            {
                tm.text = timeLeft.ToString("F");
            }
        }
        else
        {
            //game is over!
            GameManager gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
            gameManager.TimeUp();
        }
        
    }
}
