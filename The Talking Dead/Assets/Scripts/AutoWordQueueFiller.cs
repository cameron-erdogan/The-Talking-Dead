using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWordQueueFiller : MonoBehaviour {

	public WordQueue WordQueue;

	private string[] testWords = {
		"hamburger", 
		"take",
		"bacon", 
		"desk", 
		"explain", 
		"bruise",
		"chair", 
		"exclamation", 
		"hat", 
		"shirt", 
		"Antarctica", 
		"whiteboard", 
		"marker", 
		"lettuce", 
		"run"
	};

	// Use this for initialization
	void Start () {
		for (int i = 0; i < testWords.Length; i++) {
			WordQueue.AddWordToQueue (testWords [i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
