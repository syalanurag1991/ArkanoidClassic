using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	Text gameOverText;

	// Use this for initialization
	void Start () {
		gameOverText = gameObject.GetComponent<Text> ();
		//gameOverText = gameObject.GetComponent<Text> ();	
		//StartCoroutine(MyMethod());
		gameOverText.enabled = false;
	}
	
	public void DisplayGameOver () {
		gameOverText.enabled = true;
		//yield return new WaitForSeconds(5);

		StartCoroutine(MyMethod());

		//System.Threading.Thread.Sleep(2000);
		//SceneManager.LoadScene ("Menu");
	}


	IEnumerator MyMethod() {
  		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene ("Menu");
 	}

}
