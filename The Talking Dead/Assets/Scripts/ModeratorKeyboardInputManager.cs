using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ModeratorKeyboardInputManager : MonoBehaviour {

	public GameManager GameManager;

	private InputField inputField;

	// Use this for initialization
	void Start () {
		inputField = GetComponent<InputField> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ProcessTextInput(string inputText){
        
        //if our text contains a newline, it means we pressed enter and should "submit" this word
        if (inputText.Length > 0) {
            
            if (inputText.Contains("\n")) {
//                print(inputText);
                inputText = inputText.Replace("\n", "");              
                GameManager.KillZombieWithWord (inputText);
				inputField.text = "";
			}
		}
	}
}
