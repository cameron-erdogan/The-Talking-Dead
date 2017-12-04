using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabAggregateVote : MonoBehaviour {

	public Image Vote;
	private float StartVote = 0.5f;
	public static float VoteUI;

	public VoteAggregator voteAggregator;

	// Use this for initialization
	void Start () {

		Vote = GetComponent<Image> ();
		//start at 0.5 for neutral
		Vote.fillAmount = StartVote;

	}
	
	// Update is called once per frame
	void Update () {
        Vote.fillAmount = voteAggregator.GetCurrentAvg();
	}
}