using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoteAggregator : MonoBehaviour {

	public static int UpvoteDownvote;

	public int[] aggregate = new int[] {}; 
	private int nextIndex = 0;
	private int count = 0;

	private float avg = 0.0F;
	private int sum = 0;

	void Start () {

		//take vote and add to array
		count = count+1;

		if ( count%10 == 0 ) {
			nextIndex = 0;
		}

		aggregate[nextIndex++] = twitchChat.UpvoteDownvote;
	}

	public int CalculateSum(params int[] aggregate) {

		for ( int i = 0; i < aggregate.Length; i++ ) {
			sum += aggregate[i];
		}
		return sum;
	}

	public decimal CalculateAvg(params int[] aggregate) {
		int sum = CalculateSum (aggregate);
		decimal avg = (decimal)sum / aggregate.Length;
		return avg;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
