using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carAI : MonoBehaviour {

	float moveForce = -0.2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		transform.Translate (new Vector3(-moveForce,0,0));

	}

	void OnCollisionStay(Collision col)
	{
		if(col.gameObject.tag=="SideWall") moveForce*=-1;

	}
}
