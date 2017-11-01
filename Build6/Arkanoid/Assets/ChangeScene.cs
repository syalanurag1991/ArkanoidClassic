using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void GoToScene() {
		print ("Game Starting!");
		SceneManager.LoadScene ("Level1");
	}
	public void GoToScene2(){
		print ("change scene here 2!");
		SceneManager.LoadScene ("Wasted");

	}


 	


}
