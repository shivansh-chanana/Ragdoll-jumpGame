using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerForce : MonoBehaviour {
	
	public Vector3 moveForce = new Vector3 (0, 0, 0);
	public Vector3 jumpForce = new Vector3 (0, 0, 0);

	public Rigidbody rb;

	void Start ()	 {
		rb = GetComponent<Rigidbody> ();
	}
		
	void Update(){
		if (Input.GetKeyDown (KeyCode.Space))
			jump ();
	}
	void FixedUpdate () {
		rb.AddTorque (-moveForce * Time.deltaTime * 60);
	}

	public void jump(){
		rb.AddForce (jumpForce * Time.deltaTime * 60,ForceMode.Impulse);
	}

}
