using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptPlaces : MonoBehaviour {

	public TextMesh two;

	// Use this for initialization
	void Start () {

		two = GetComponent<TextMesh>();
        two.text = RandomPrompt.inst.place;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}