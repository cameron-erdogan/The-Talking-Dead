﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRemainingTime : MonoBehaviour
{

	TextMesh tm;

	private double timeLeft;

	GameManager gameManager;

	// Use this for initialization
	void Start ()
	{
		tm = GetComponent<TextMesh> ();
		gameManager = GameObject.FindGameObjectWithTag ("Game Manager").GetComponent<GameManager> ();
	}

	// Update is called once per frame
	void Update ()
	{
		timeLeft = gameManager.timeLeft;
		if (tm.text != timeLeft.ToString ("F0")) {
			tm.text = timeLeft.ToString ("F0");
		}
        
	}

	public double GetRemainingTime ()
	{
		return timeLeft;
	}
}
