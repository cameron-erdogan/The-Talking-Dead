 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFactory : MonoBehaviour {

	public GameManager GameManager;
	public float Radius;
	public GameObject ZombiePrefab;

	private float spawnArcAngle = 180f;

	// Use this for initialization


	//spawns zombie and returns 
	public GameObject SpawnZombie(string word){
		Vector3 spawnPoint = Vector3.forward * Radius + Vector3.up * 0.4f;
		float randomAngle = Random.value * spawnArcAngle - spawnArcAngle / 2f;
		spawnPoint = Quaternion.Euler (0, randomAngle, 0) * spawnPoint;

		GameObject thisZombie = Object.Instantiate (ZombiePrefab, spawnPoint, Quaternion.identity) as GameObject;
		thisZombie.transform.LookAt (GameObject.FindGameObjectWithTag ("Player").transform);
		thisZombie.GetComponent<WordZombie> ().SetLabel (word);

		return thisZombie;
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, Radius);
	}
}
