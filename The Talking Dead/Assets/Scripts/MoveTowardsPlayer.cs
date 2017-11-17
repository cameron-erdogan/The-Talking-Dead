﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour {

	public float Speed = 1f;
	private Transform player;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update() {
		float step = Speed * Time.deltaTime;
		float oldY = transform.position.y;
		transform.position = Vector3.MoveTowards(transform.position, player.position, step);
		transform.position = new Vector3 (transform.position.x, oldY, transform.position.z);
		transform.LookAt (player);
	}
}
