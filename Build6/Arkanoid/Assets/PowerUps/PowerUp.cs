using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	float speed = 3f;
	Rigidbody2D rb2d;
	AudioSource powerUpAudio;
	ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		rb2d.velocity = new Vector2 (0, -1*speed);
		powerUpAudio = gameObject.GetComponent<AudioSource> ();
		scoreManager = FindObjectOfType<ScoreManager>();
	}
	
	//This code destroys the PowerUpPrefab upon upon collision with Vaus or shredder
	//The collisions have been neatly defined in the "Physics2D Engine"
	void OnCollisionEnter2D (Collision2D collision)	{
		if (collision.collider.gameObject.tag == "Player") {
			scoreManager.IncreaseScore (100);
			powerUpAudio.Play ();
			Destroy (gameObject, 0.1f);
		}
	}
}
