using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabAggregateVote : MonoBehaviour {

	public Image Vote;
	private float StartVote = 0.5f;
	public static float VoteUI;

	public twitchChat avg;
	public VoteAggregator voteAggregator;

	// Use this for initialization
	void Start () {

		Vote = GetComponent<Image> ();
		//start at 0.5 for neutral
		VoteUI = StartVote;
	}
	
	// Update is called once per frame
	void Update () {

		if (VoteAggregator.aggregate == null) {
			Vote.fillAmount = VoteUI;
		} else {
			Vote.fillAmount = twitchChat.avg;
		}
	}
}