using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiMove : MonoBehaviour {

	public Rigidbody rb;

	public float moveSpeed = 0.1f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		rb.transform.Translate (moveSpeed, 0, 0);	
	}

	void OnCollisionEnter(Collision col){
	
		if (col.gameObject.tag	 == "edge")
			moveSpeed *= -1;
	}

}
