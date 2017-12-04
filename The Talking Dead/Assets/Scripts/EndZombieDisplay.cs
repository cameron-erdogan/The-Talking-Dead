using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZombieDisplay : MonoBehaviour
{

	TextMesh tm;

	private int zombieCount;

	GameManager gameManager;

	// Use this for initialization
	void Start ()
	{
		tm = GetComponent<TextMesh> ();
		gameManager = GameObject.FindGameObjectWithTag ("Game Manager").GetComponent<GameManager> ();
		zombieCount = gameManager.zombieKilled;
		tm.text = zombieCount.ToString ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
