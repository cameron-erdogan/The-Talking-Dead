using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordZombie : MonoBehaviour {

	public TextMesh wordLabel;

	public void SetLabel(string word){
		wordLabel.text = word;
	}
}
