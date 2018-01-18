using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManagerScript : MonoBehaviour {

	public string loadScene;

	public void sceneChange(){
		SceneManager.LoadScene (loadScene);
	}
}
