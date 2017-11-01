using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickController : MonoBehaviour {

	ScoreManager scoreManager;
	AudioSource hit;

	public int brickStrength = 1;
	public int brickPoints = 50;

	SpriteRenderer brickRenderer;
	Collider2D brickCollider;

	public Transform EnlargeCapsule;
	public Transform SlowCapsule;
	public Transform LaserCapsule;

	public int whichPowerUp;

	// Use this for initialization
	void Start () {
		scoreManager = FindObjectOfType<ScoreManager>();
		brickRenderer = gameObject.GetComponent<SpriteRenderer> ();
		brickCollider = gameObject.GetComponent<Collider2D>();
		hit = gameObject.GetComponent<AudioSource>();
	}

	//This code destroys the brick upon collision and plays audioclip
	void OnCollisionEnter2D (Collision2D theOtherObjectCollider)
	{
		//audioSource.Play ();
		scoreManager.IncreaseScore (brickPoints);

		brickStrength--;

		whichPowerUp = Random.Range (1, 15);
		if (whichPowerUp == 1) {
			Instantiate (EnlargeCapsule, transform.position, EnlargeCapsule.rotation);
			EnlargeCapsule.tag = "powerup";
		}

		if (whichPowerUp == 2) {
			Instantiate (SlowCapsule, transform.position, SlowCapsule.rotation);
			SlowCapsule.tag = "powerup";
		}

		if (whichPowerUp == 3) {
			Instantiate (LaserCapsule, transform.position, LaserCapsule.rotation);
			LaserCapsule.tag = "powerup";
		}

		if (brickStrength == 0) {
			scoreManager.BrickDead ();
			brickRenderer.enabled = false;
			brickCollider.enabled = false;
			Destroy (gameObject, 5f * Time.deltaTime);
			hit.Play ();
		}

	}

}