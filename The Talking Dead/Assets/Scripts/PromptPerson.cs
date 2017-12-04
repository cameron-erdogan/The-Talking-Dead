using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptPerson : MonoBehaviour {

	public TextMesh one;

	// Use this for initialization
	void Start () {

		one = GetComponent<TextMesh>();
        one.text = RandomPrompt.inst.person;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}