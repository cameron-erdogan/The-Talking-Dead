using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour {

	// Use this for initialization

	void OnTriggerEnter(Collider other) {
		print ("collided with " + other.tag);
		if (other.tag == "Player") {
			//could do something to player
			//just kill myself for now
//			Destroy(this.gameObject);
		}
	}
}
