using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompt : MonoBehaviour {

	private string person;
	private string place;
	private string action;

	private string[] PersonArray = {
		"person1", "person2", "person3",	
	};

	private string[] PlacesArray = {
		"place1", "place2", "place3",
	};

	private string[] ActionsArray = {
		"action1", "action2", "action3",
	};

	// Use this for initialization
	void Start () {
		
		string[][] RandomPrompt = {
			PersonArray, PlacesArray, ActionsArray,
		};

		for ( int i = 0; i < RandomPrompt.Length; i++ ) {
			for (int j = 0; j < RandomPrompt[i].Length; j++) {
				var prompt = Random.Range(0, RandomPrompt.Length);
				Debug.LogError (RandomPrompt [prompt]);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}