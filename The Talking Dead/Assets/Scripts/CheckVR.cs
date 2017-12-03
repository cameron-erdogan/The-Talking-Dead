using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CheckVR : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		if (UnityEngine.XR.XRSettings.enabled == true) {
			Debug.Log ("VR Enabled");
		} else {
			Debug.Log ("VR Disabled");
			//Destroy this whole gameobject though
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
