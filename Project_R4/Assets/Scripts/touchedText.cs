using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touchedText : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start () {
		text.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (controllerForce.death) {
			text.enabled = true;
		}
	}
}
