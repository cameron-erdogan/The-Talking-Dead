using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRemainingTime : MonoBehaviour {

    TextMesh tm;

    private double totalTime = 12.00;

    // Use this for initialization
    void Start()
    {
        tm = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        double timeLeft = totalTime - Time.time;
        if(timeLeft >= 0)
        {
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
