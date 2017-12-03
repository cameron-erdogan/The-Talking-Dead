using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoteAggregator : MonoBehaviour {

//	public static int UpvoteDownvote;

	public static int[] aggregate; 
	private int nextIndex = 0;
	private int count = 0;

	private float avg = 0.0F;
	private int sum = 0;

	void Start () {

		aggregate = new int[10];

		//take vote and add to array
//		count = count+1;
//
//		if ( count%10 == 0 ) {
//			nextIndex = 0;
//		}
//
//		//put upvote or downvote into the array from twitchChat
//		aggregate[nextIndex++] = twitchChat.UpvoteDownvote;
	}

	public void Vote(int vote){

		//take vote and add to array
		count = count+1;

		//put upvote or downvote into the array from twitchChat
		aggregate[nextIndex] = vote;
		nextIndex++;

		if ( nextIndex%10 == 0 ) {
			nextIndex = 0;
		}

	}

	public int CalculateSum() {

		sum = 0;

		//create a sum
		for ( int i = 0; i < aggregate.Length; i++ ) {
			sum += aggregate[i];
		}
		Debug.Log (sum);
		return sum;
	}

	public float CalculateAvg() {

		//create average and return it for UI element
		int sum = CalculateSum ();
		float avg = (float)sum / count;

		Debug.Log (avg);
		return avg;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
