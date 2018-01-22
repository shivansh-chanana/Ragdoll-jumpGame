using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScript : MonoBehaviour {

	public Rigidbody2D rb;

	public controllerForce cf;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) jump ();
	}


	public void jump(){
	//	if(cf.colWithWalls && controllerForce.death) rb.AddForce (transform.up * cf.jumpForce,ForceMode2D.Impulse )//* Time.fixedDeltaTime * 60,ForceMode2D.Impulse);
	}
}
