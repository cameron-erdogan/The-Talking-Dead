using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordQueue : MonoBehaviour {

	public GameManager GameManager;

	private Queue premadeQueue;
	private Queue queue;

	// Use this for initialization
	void Awake () {
		queue = new Queue ();
		premadeQueue = new Queue ();
	}

	void Start(){
		GameManager = GameObject.FindGameObjectWithTag ("Game Manager").GetComponent<GameManager> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	//public void AddWordToQueue(string word){
	//	queue.Enqueue (word);
	//}

    public void AddInfoToQueue(ZombieInfo info)
    {
        queue.Enqueue(info);
    }

	//public void AddWordToPremadeQueue(string word){
	//	premadeQueue.Enqueue (word);
	//}

    public void AddInfoToPremadeQueue(ZombieInfo info)
    {
        premadeQueue.Enqueue(info);
    }

	public bool HasNextZombieInfo(){
		return (queue.Count > 0) || (premadeQueue.Count > 0);
	}

	//should only call this if you've checked that HasNextWord() returns true
	//you'll get errorz otherwise
    public ZombieInfo GetNextZombieInfo()
    {
        if (queue.Count > 0){
            return queue.Dequeue() as ZombieInfo;
        }
        else{
            return premadeQueue.Dequeue() as ZombieInfo;
        }
    }
}
