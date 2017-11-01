using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour {

	Text YouWinText;

	// Use this for initialization
	void Start () {
		YouWinText = gameObject.GetComponent<Text> ();
		YouWinText.enabled = false;
	}
	
	public void DisplayYouWin () {
		YouWinText.enabled = true;
		StartCoroutine(MyMethod());
	}

	IEnumerator MyMethod() {
  		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene ("Menu");
 	}
}
