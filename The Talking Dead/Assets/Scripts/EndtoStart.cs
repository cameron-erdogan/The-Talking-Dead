using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndtoStart : MonoBehaviour
{

    private GameObject gameManager;
    private GameObject randomPrompt;

	// Use this for initialization
	void Start ()
	{
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        randomPrompt = GameObject.FindGameObjectWithTag("Random Prompt");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown ("space")) {
//			SceneManager.LoadScene (0);
//			Destroy (GameObject.FindGameObjectWithTag ("Game Manager"));
			Debug.Log ("should go back to start screen");
            Destroy(gameManager);
            Destroy(randomPrompt);

            SceneManager.LoadScene(0);
		}
	}
}
