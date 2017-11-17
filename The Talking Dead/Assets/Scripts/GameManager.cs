using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public WordQueue WordQueue;
	public ZombieFactory ZombieFactory;

	private List<GameObject> currentZombies;
	private float zombieTimer = 0f;
	private float spawnRate = 2f;

	// Use this for initialization
	void Start () {
		currentZombies = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		ZombieUpdate ();
	}

	private void ZombieUpdate(){
		//should handle the timer stuff here
		zombieTimer += Time.deltaTime;
		if (zombieTimer > spawnRate) {
			//should get word from word queue
			string word = WordQueue.GetNextWord();
			currentZombies.Add(ZombieFactory.SpawnZombie (word));
			zombieTimer = 0;
		}
	}
}
