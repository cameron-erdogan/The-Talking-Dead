using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordQueue : MonoBehaviour {

	public GameManager GameManager;

	private Queue queue;

	// Use this for initialization
	void Awake () {
		queue = new Queue ();
	}

	void Start(){
		GameManager = GameObject.FindGameObjectWithTag ("Game Manager").GetComponent<GameManager> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void AddWordToQueue(string word){
		queue.Enqueue (word);
	}

	public string GetNextWord(){
		return queue.Dequeue () as string;
	}
}
