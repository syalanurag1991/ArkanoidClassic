using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	GameOver gameOver;
	Vaus vaus;

	// Use this for initialization
	void Start () {
		gameOver = FindObjectOfType<GameOver>();
		vaus = FindObjectOfType<Vaus>();

	}
	
	void OnTriggerEnter2D (Collider2D theOtherObject){
		Destroy (theOtherObject.gameObject, 0.001f);
		if (theOtherObject.gameObject.tag == "ball") {
			gameOver.DisplayGameOver ();
			vaus.DestroyVaus();
			//yield return new WaitForSeconds(3);
		}
	}

}

	