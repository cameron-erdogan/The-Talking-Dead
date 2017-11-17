using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordZombie : MonoBehaviour, System.IEquatable<WordZombie> {

	public TextMesh wordLabel;

	public void SetWord(string word){
		wordLabel.text = word;
	}

	public string GetWord(){
		return wordLabel.text;
	}

	public bool Equals(WordZombie otherZombie){
		print ("comparing jawns");
		return GetWord ().Equals (otherZombie.GetWord ());
	}
}
