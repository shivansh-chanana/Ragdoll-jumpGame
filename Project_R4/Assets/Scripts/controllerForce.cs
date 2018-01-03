using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controllerForce : MonoBehaviour {

	#region Variables Initialize
	public Vector3 moveForce = new Vector3 (0, 0, 0);
	public Vector3 jumpForce = new Vector3 (0, 0, 0);

	public Rigidbody rb;

	private bool colWithWalls = false;

	#endregion

	void Start ()	 {
		rb = GetComponent<Rigidbody> ();
	}
		
	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) jump ();
	}
	void FixedUpdate () {
		rb.AddTorque (-moveForce * Time.deltaTime * 60);
	}

	#region Collision Stuff
	void OnTriggerEnter(Collider triggerTarget){
		if (triggerTarget.tag == "Walls") {
			Debug.Log ("CAN jump Now");
			colWithWalls = true;
		}

		if (triggerTarget.tag == "Finish") {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

	void OnTriggerStay(Collider triggerTarget){
		if (triggerTarget.tag == "Walls") {
			Debug.Log ("CAN jump Now");
			colWithWalls = true;
		}
	}

	void OnTriggerExit(Collider triggerTarget){
			Debug.Log ("CANNOT jump Now");
			colWithWalls = false;
	}
	#endregion

	public void jump(){
		if(colWithWalls) rb.AddForce (jumpForce * Time.deltaTime * 60,ForceMode.Impulse);
	}

}
