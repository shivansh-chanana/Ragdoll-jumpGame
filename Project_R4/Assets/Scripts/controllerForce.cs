using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controllerForce : MonoBehaviour {

	#region Variables Initialize
	public Vector3 moveForce = new Vector3 (0, 0, 0);
	public Vector3 jumpForce = new Vector3 (0, 0, 0);

	public Rigidbody rb;

	public Text pauseText;

	private bool colWithWalls = false;

	public static bool death = false;

	public static bool paused = false;

	#endregion

	void Awake(){
		reset ();
	}

	void Start ()	 {
		rb = GetComponent<Rigidbody> ();
	}
		
	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) jump ();
		if (Input.GetKeyDown (KeyCode.Z) && paused == false) pausedMethod ();
		if (Input.GetKeyDown (KeyCode.X) && paused == true) resume ();	
		//if (Input.GetKeyDown (KeyCode.Z))
			//rb.AddForce (5, 0, 0,ForceMode.Impulse);
	}

	void FixedUpdate () {
		if(!death) rb.AddTorque (-moveForce*Time.fixedDeltaTime * 60);
	}

	#region Collision Stuff

	void OnTriggerEnter(Collider triggerTarget){
		if (triggerTarget.tag == "Walls") {
			Debug.Log ("CAN jump Now");
			colWithWalls = true;
		}

		if (triggerTarget.tag == "Finish") {
			reSpawn ();
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
		if(colWithWalls && !death) rb.AddForce (jumpForce*Time.fixedDeltaTime * 60,ForceMode.Impulse);
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
}
