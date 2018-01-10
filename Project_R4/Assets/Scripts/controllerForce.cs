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

	public bool death = false;

	private float delayTime = 2f;

	#endregion

	void Start ()	 {
		rb = GetComponent<Rigidbody> ();
	}
		
	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) jump ();
	}
	void FixedUpdate () {
		if(!death) rb.AddTorque (-moveForce * Time.deltaTime * 60);
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

	void OnCollisionEnter(Collision collisionTarget)
	{
		//COLLISION WITH GAMEOVER OBJECT TAG
		if (collisionTarget.gameObject.name =="peopleLying") {
			Debug.Log ("Start Coroutine");
			StartCoroutine (gameOver (delayTime)); 
		}
	}

	#endregion

	public void jump(){
		if(colWithWalls && !death) rb.AddForce (jumpForce * Time.fixedDeltaTime * 60,ForceMode.Impulse);
	}

	IEnumerator gameOver(float delayTime){
	
		death = true;

		Debug.Log("GameOver Buddy");
		yield return new WaitForSeconds (delayTime);

		reSpawn ();
	}

	void reSpawn(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
