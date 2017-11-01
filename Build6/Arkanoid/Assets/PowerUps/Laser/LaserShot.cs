using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour {

	float speed = 8f;
	Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		rb2d.velocity = new Vector2 (0, speed);
	}

	//This code destroys the LaserShotPrefab upon upon collision with a brick or borders
	//The collisions have been neatly defined in the "Physics2D Engine"
	void OnCollisionEnter2D (Collision2D collision) {
		Destroy (gameObject);
	}


}