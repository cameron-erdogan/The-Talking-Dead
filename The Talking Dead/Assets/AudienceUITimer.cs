using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudienceUITimer : MonoBehaviour
{

	Text tm;

	private double totalTime = 120.00;
	private double startTime;

	// Use this for initialization
	void Start ()
	{
		tm = GetComponent<Text> ();
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update ()
	{
		double timeElapsed = Time.time - startTime;
		if (timeElapsed < totalTime) {
			double timeLeft = totalTime - timeElapsed;
			if (tm.text != timeLeft.ToString ("N0")) {
				tm.text = timeLeft.ToString ("N0");
			}
		} else {
			//game is over!
			GameManager gameManager = GameObject.FindGameObjectWithTag ("Game Manager").GetComponent<GameManager> ();
			gameManager.TimeUp ();
		}

	}
}
