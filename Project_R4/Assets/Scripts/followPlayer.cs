using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

	public Transform player;

	public float xSpeed;
	public float ySpeed;

	// Use this for initialization
	void Start () {
		//player = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.position.x + xSpeed, Mathf.Lerp(transform.position.y,player.position.y + ySpeed,0.05f), -10);
	}
}
