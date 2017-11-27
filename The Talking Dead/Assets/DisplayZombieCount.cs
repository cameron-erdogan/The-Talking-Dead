using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayZombieCount : MonoBehaviour {

    public GameManager gm;
    TextMesh tm;

	// Use this for initialization
	void Start () {
        tm = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        if(tm.text != gm.zombieKilled.ToString())
        {
            tm.text = gm.zombieKilled.ToString();
        }
	}
}
