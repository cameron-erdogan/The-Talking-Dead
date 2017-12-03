using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptToTextSize : MonoBehaviour {

	private TextMesh parentTextMesh;
	private BoxCollider parentBoxCollider;
	private MeshFilter meshFilter;
	private MeshRenderer meshRenderer;

	// Use this for initialization
	void Start () {
		meshFilter = GetComponent<MeshFilter> ();
		parentBoxCollider = GetComponentInParent<BoxCollider> ();
		meshFilter.mesh.bounds = parentBoxCollider.bounds;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
