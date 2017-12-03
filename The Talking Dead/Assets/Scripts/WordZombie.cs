using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordZombie : MonoBehaviour, System.IEquatable<WordZombie> {

	public TextMeshPro wordLabel;

	private string word;

	public void SetWord(string word){
		this.word = word;
		wordLabel.text = word;
	}

	public string GetWord(){
		return word;
	}

	public bool Equals(WordZombie otherZombie){
		print ("comparing jawns");
		return GetWord ().Equals (otherZombie.GetWord ());
	}
}
