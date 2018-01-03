using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerForce : MonoBehaviour {
	
	public Vector3 moveForce = new Vector3 (0, 0, 0);
	public Vector3 jumpForce = new Vector3 (0, 0, 0);

	public Rigidbody rb;
	bool pointerDownLeft = false;
	bool pointerDownRight = false;

	void Start ()	 {
		rb = GetComponent<Rigidbody> ();
	}
		
	void Update(){
		if (Input.GetKeyDown (KeyCode.A)) leftEnabled ();
		if (Input.GetKeyUp (KeyCode.A))  leftDisabled();
		if (Input.GetKeyDown (KeyCode.S)) rightEnabled ();
		if (Input.GetKeyUp (KeyCode.S))  rightDisabled();

		if (Input.GetKeyDown (KeyCode.S)) rb.AddForce (jumpForce * Time.deltaTime * 60,ForceMode.Impulse);

	}
	void FixedUpdate () {
		//if(pointerDownLeft) rb.AddTorque (moveForce * Time.deltaTime * 60);
		rb.AddTorque (-moveForce * Time.deltaTime * 60);
		//if(pointerDownRight) rb.AddTorque (-moveForce * Time.deltaTime * 60);
		//if(pointerDownRight) rb.AddForce (jumpForce * Time.deltaTime * 60);
	}

	#region leftEnabled
	public void leftEnabled(){
		pointerDownLeft = true;
	}
		
	public void leftDisabled(){
		pointerDownLeft = false;
	}
	#endregion

	#region rightEnabled
	public void rightEnabled(){
		pointerDownRight = true;
	}

	public void rightDisabled(){
		pointerDownRight = false;
	}
	#endregion
}
