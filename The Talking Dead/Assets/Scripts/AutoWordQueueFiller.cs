using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWordQueueFiller : MonoBehaviour {

	public WordQueue WordQueue;

	private string[] testWords = {
		"cockroach",
		"hobo",
		"Mario",
		"cake",
		"rover",
		"vulture",
		"skip",
		"lake",
		"parachute",
		"McDonalds",
		"dance",
		"plate",
		"drive",
		"sleek",
		"kitten",
		"snowflake",
		"haunt",
		"rap",
		"thunder",
		"fiddle",
		"Jupiter",
		"Zelda",
		"soar",
		"patriarchy",
		"vicissitudes",
		"alien",
		"airplane",
		"fly",
		"gravity",
		"empty",
		"laugh",
		"red",
		"pungent",
		"gourmet",
		"quixotic",
		"handkerchief",
		"rhythm",
		"pharoah",
		"Ares",
		"wormhole",
		"kingdom",
		"agriculture",
		"clouds",
		"hair",
		"dragon",
		"wealthy",
		"canyon",
		"tumbling",
		"Einstein",
		"moustache",
		"exciting", "gland", "paralysed", "gargoyle", "atrocity", "enter", "carcinogenic", "compartment", "hairless", "pull", "comrade", "best", "collectable", "patient", "gimmick", "fluctuation", "formal", "grave", "favor", "prophet", "sexiest", "daydreamer", "cynical", "predict", "fraction", "boundary", "drink", "someone", "mistaken", "cartel", "flower"
		};


	// Use this for initialization
	void Start () {
		for (int i = 0; i < testWords.Length; i++) {
			WordQueue.AddWordToPremadeQueue (testWords [i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
