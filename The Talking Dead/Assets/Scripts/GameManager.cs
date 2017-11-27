using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public WordQueue WordQueue;
	public ZombieFactory ZombieFactory;

	private List<WordZombie> currentZombies;
	private float zombieTimer = 0f;
	private float spawnRate = 2f;
	private float maxZombies = 4;

    public int zombieKilled = 0;

	// Use this for initialization
	void Start () {
		currentZombies = new List<WordZombie> ();
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

			if (currentZombies.Count < maxZombies) {
				string word = WordQueue.GetNextWord ();
				currentZombies.Add (ZombieFactory.SpawnZombie (word));
			}
			zombieTimer = 0;
		}
	}

	public void KillZombieWithWord(string word){
		print ("should kill zombie with word " + word);

		List<WordZombie> zombiesToRemove = new List<WordZombie> ();
		foreach (WordZombie zombie in currentZombies) {
			if (zombie.GetWord ().Equals (word)) {
				zombiesToRemove.Add (zombie);
                zombieKilled++;
            }
		}

		foreach (WordZombie zombie in zombiesToRemove) {
			currentZombies.Remove (zombie);
			Destroy (zombie.gameObject);  
        }
		print (currentZombies.Count);
		 
	}

	public void ZombieAttackedPlayer(WordZombie zombie){
		Debug.Log ("zombie killed you! " + zombie.GetWord());
		Time.timeScale = 0;

        print("zombies killed: " + zombieKilled);

    }

    public void TimeUp()
    {
        Time.timeScale = 0;

        print("you survived!");
    }
}

