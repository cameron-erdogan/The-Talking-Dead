using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public WordQueue WordQueue;
	public ZombieFactory ZombieFactory;
	public AudienceUI AudienceUI;
	public VoteAggregator VoteAggregator;

	private List<WordZombie> currentZombies;
	private float zombieTimer = 0f;
	private float spawnRate = 3f;
	private float maxZombies = 4;

	public int zombieKilled = 0;

	private double totalTime = 120.00;
	private double startTime;
	public double timeElapsed;
	public double timeLeft;

	// Use this for initialization
	void Start ()
	{
		currentZombies = new List<WordZombie> ();
		startTime = Time.time;
		timeLeft = totalTime;
	}

    // Update is called once per frame
    void Update()
    {
        ZombieUpdate();

        if (AudienceUI != null)
        {
            AudienceUI.UpdateText(currentZombies);
        }

        TimeUpdate();

        if (Input.GetKeyDown("space"))
        {
            TimeUp();
        }

		updateZombieSpeed ();
    }

	private void updateZombieSpeed (){
		//should be 0.5 initially

		//need to find 1 - average for parametric value because 1 is slow and 0 is fast.
		float t = 1f - VoteAggregator.GetCurrentAvg ();

		//we want 0.5 value to map to MoveTowardsPlayer.BaseSpeed
		float lowerLimit = MoveTowardsPlayer.BaseSpeed - 0.2f;
		float upperLimit = MoveTowardsPlayer.BaseSpeed + 0.2f;

		MoveTowardsPlayer.Speed = Mathf.Lerp (lowerLimit, upperLimit, t);
	}

	private void ZombieUpdate ()
	{
		//should handle the timer stuff here
		zombieTimer += Time.deltaTime;
		if (zombieTimer > spawnRate) {
			//should get word from word queue

			if (currentZombies.Count < maxZombies && WordQueue.HasNextZombieInfo () == true) {
				ZombieInfo info = WordQueue.GetNextZombieInfo ();
				if (ZombieFactory != null) {
					currentZombies.Add (ZombieFactory.SpawnZombie (info));
				}

			}
			zombieTimer = 0;
		}
	}

	public void KillZombieWithWord (string word)
	{
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

	public void ZombieAttackedPlayer (WordZombie zombie)
	{
		Debug.Log ("zombie killed you! " + zombie.GetWord ());
		Time.timeScale = 0;

		print ("zombies killed: " + zombieKilled);

		//call deathevent
		DeathEvent ();
	}

	private void TimeUpdate ()
	{
		timeElapsed = Time.time - startTime;
		if (timeElapsed < totalTime) {
			timeLeft = totalTime - timeElapsed;
		} else {
			//game is over!
			TimeUp ();
		}
	}

	public void TimeUp ()
	{
		//Time.timeScale = 0;

		print ("you survived!");

		//call deathevent
		DeathEvent ();
	}

	public void AddInfoToWordQueue (ZombieInfo info)
	{
		WordQueue.AddInfoToQueue (info);
        
	}

	private void DeathEvent ()
	{
		//load gameover scene
		SceneManager.LoadScene (3);
	}

	void Awake ()
	{
		DontDestroyOnLoad (this);
	}
}

