using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour {

	// Use this for initialization

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			//should tell the game manager that this zombie attacked the player
			WordZombie zombie = GetComponent<WordZombie>();
			GameManager gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();

			if (zombie != null && gameManager != null) {
				gameManager.ZombieAttackedPlayer (zombie);
			} else {
				Debug.Log ("word zombie or game manager is null, shouldn't be null");
			}
		}
	}
}
