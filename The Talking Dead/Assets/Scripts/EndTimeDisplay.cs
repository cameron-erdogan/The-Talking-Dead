using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTimeDisplay : MonoBehaviour
{

	TextMesh tm;

	private double timeLeft;

	GameManager gameManager;

	// Use this for initialization
	void Start ()
	{
		tm = GetComponent<TextMesh> ();
		gameManager = GameObject.FindGameObjectWithTag ("Game Manager").GetComponent<GameManager> ();
		timeLeft = gameManager.timeLeft;
		tm.text = timeLeft.ToString ("F0");
	}

	// Update is called once per frame
	void Update ()
	{

	}
}
