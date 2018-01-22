using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyTouchScript : MonoBehaviour {

	public controllerForce cf;

	public float slowMoWait = 0f;

	void OnCollisionEnter2D(Collision2D collisionTarget)
	{
		
		//COLLISION WITH GAMEOVER OBJECT TAG
			if (collisionTarget.gameObject.tag == "GameOver") {
				if (!controllerForce.death) {
						Debug.Log ("Touch Down" + "  " + "Touch = " + controllerForce.death);
						controllerForce.death = true;	
						Debug.Log ("Start Coroutine");
						StartCoroutine (slowMo (slowMoWait));
			}
		}
	}

	IEnumerator slowMo(float slowMoWait){
		Time.timeScale = 0.00001f;
		float pauseEndTime = Time.realtimeSinceStartup + 1f;
		while (Time.realtimeSinceStartup < pauseEndTime)
		{
			yield return 0;
		}
		Time.timeScale = 1f;
		yield return new WaitForSeconds (slowMoWait * Time.timeScale);
		cf.reSpawn ();
	}

}
