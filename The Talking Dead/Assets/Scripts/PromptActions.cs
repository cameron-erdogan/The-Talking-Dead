using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptActions : MonoBehaviour {

	public TextMesh three;

	// Use this for initialization
	void Start () {
			
		three = GetComponent<TextMesh>();
		three.text = RandomPrompt.inst.action;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}