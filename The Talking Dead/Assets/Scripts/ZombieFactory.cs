using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFactory : MonoBehaviour {

	public float radius;
	public float spawnRate;
	public GameObject zombiePrefab;

	private float spawnArcAngle = 180f;
	private float currentTime = 0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime > spawnRate) {
			spawnZombie ();
			currentTime = 0;
		}
	}

	void spawnZombie(){
		print ("spawning zombie");
		Vector3 spawnPoint = Vector3.forward * radius + Vector3.up * 0.4f;
		float randomAngle = Random.value * spawnArcAngle - spawnArcAngle / 2f;

		spawnPoint = Quaternion.Euler (0, randomAngle, 0) * spawnPoint;
		GameObject thisZombie = Object.Instantiate (zombiePrefab, spawnPoint, Quaternion.identity) as GameObject;
		thisZombie.transform.LookAt (GameObject.FindGameObjectWithTag ("Player").transform);
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, radius);
	}
}
