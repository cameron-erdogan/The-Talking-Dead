using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoteAggregator : MonoBehaviour {

//	public static int UpvoteDownvote;

	public static float[] aggregate; 
	private int nextIndex = 0;

	private float currentAvg = 0.0F;

    void Start() {

        aggregate = new float[10];
        for (int i = 0; i < aggregate.Length; i++)
        {
            aggregate[i] = 0.5f;
        }

        updateCurrentAvg();
	}

	public void Vote(int vote){

		//put upvote or downvote into the array from twitchChat
		aggregate[nextIndex] = vote;
		nextIndex++;

		if ( nextIndex%10 == 0 ) {
			nextIndex = 0;
		}

        updateCurrentAvg();
	}

	public float CalculateSum() {

		float sum = 0;

		//create a sum
		for ( int i = 0; i < aggregate.Length; i++ ) {
			sum += aggregate[i];
		}
		//Debug.Log (sum);
		return sum;
	}

	private float calculateAvg() {

		//create average and return it for UI element
		float sum = CalculateSum ();
		float avg = sum / aggregate.Length;

		//Debug.Log (avg);
		return avg;
	}

    private void updateCurrentAvg()
    {
        currentAvg = calculateAvg();
    }

    public float GetCurrentAvg()
    {
        return currentAvg;
    }
	
}
