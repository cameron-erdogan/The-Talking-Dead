using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWordQueueFiller : MonoBehaviour {

	public WordQueue WordQueue;

	private string[] testWords = {
		"cabbage", 
		"fire", 
		"lightning", 
		"automobile", 
		"rockstar", 
		"mortal", 
		"rutabaga", 
		"antelope", 
		"whiskey", 
		"gobble", 
		"ogre", 
		"fright", 
		"solar", 
		"mangled", 
		"toast", 
		"applesauce", 
		"aunty", 
		"bombastic", 
		"kaleidoscope", 
		"tree", 
		"angel", 
		"history", 
		"wand", 
		"wings", 
		"science", 
		"magnet", 
		"zebra", 
		"yellow",
		"mobile",
		"shepherd",
		"dragon",
		"romance",
		"spatula",
		"oven",
		"lemon",
		"illness",
		"mountain",
		"guard",
		"lozenge",
		"idiocy",
		"army",
		"heathered",
		"petticoat",
		"livid",
		"lifestyle",
		"gobble",
		"platter",
		"electric",
		"telephone"
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
