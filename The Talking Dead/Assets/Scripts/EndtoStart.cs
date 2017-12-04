using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndtoStart : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown ("space")) {
//			SceneManager.LoadScene (0);
//			Destroy (GameObject.FindGameObjectWithTag ("Game Manager"));
			Debug.Log ("should go back to start screen");
		}
	}
}
