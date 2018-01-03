using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class leftButton : MonoBehaviour {

	public controllerForce cF;

	public void OnPointerDown(){
		cF.leftEnabled ();
	}

	public void OnPointerUp(){
		cF.leftDisabled ();
	}
}
