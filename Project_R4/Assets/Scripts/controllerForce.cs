using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controllerForce : MonoBehaviour {

	#region Variables Initialize
	public float moveForce = 0f;
	public float jumpForce = 0f;

	public Rigidbody2D rb;

	public Text pauseText;

	public bool colWithWalls = false;

	public static bool death = false;

	public static bool paused = false;

	#endregion

	void Awake(){
		reset ();
	}

	void Start ()	 {
		rb = GetComponent<Rigidbody2D> ();
	}
		
	void Update(){
	//	if (Input.GetKeyDown (KeyCode.Space)) jump ();
		if (Input.GetKeyDown (KeyCode.Z) && paused == false) pausedMethod ();
		if (Input.GetKeyDown (KeyCode.X) && paused == true) resume ();	
		//if (Input.GetKeyDown (KeyCode.Z))
			//rb.AddForce (5, 0, 0,ForceMode.Impulse);
	}

	void FixedUpdate () {
		//if (!death)
			//rb.AddTorque (-moveForce);//*Time.fixedDeltaTime * 60);
	}

	#region Collision Stuff

	void OnTriggerEnter2D(Collider2D triggerTarget){
		if (triggerTarget.tag == "Walls") {
			Debug.Log ("CAN jump Now");
			colWithWalls = true;
		}

		if (triggerTarget.tag == "Finish") {
			reSpawn ();
		}
	}

	void OnTriggerStay2D(Collider2D triggerTarget){
		if (triggerTarget.tag == "Walls") {
			Debug.Log ("CAN jump Now");
			colWithWalls = true;
		}
	}

	void OnTriggerExit2D(Collider2D triggerTarget){
			Debug.Log ("CANNOT jump Now");
			colWithWalls = false;
	}
		
	#endregion

	#region Other Methods

	public void jump(){
		if(colWithWalls && !death) rb.AddForce
			(transform.up * jumpForce * Time.fixedDeltaTime * 60,ForceMode2D.Impulse);
	}
		
	void pausedMethod(){
		pauseText.enabled = true;
		paused = true;
		Time.timeScale = 0;
			}

	void resume(){
		pauseText.enabled = false;
		paused = false;
		Time.timeScale = 1f;
	}

	void reset(){
		//Resets things
		death = false;
		pauseText.enabled = false;
	}

	public void reSpawn(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void check(){
		Debug.Log ("Reference working");
	}

	#endregion
}


