using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaus : MonoBehaviour {

	float speed = 500f;
	string powerUp = "";
	Ball ball;

	public GameObject LaserShotPrefab;
	Transform laserSpawnPoint1;
	Transform laserSpawnPoint2;
	Animator animator;


	// Use this for initialization
	void Start () {
		laserSpawnPoint1 = transform.Find("LaserSpawnPoint1");
		laserSpawnPoint2 = transform.Find("LaserSpawnPoint2");
		animator = GetComponent<Animator>();
		ball = FindObjectOfType<Ball>();
	}

	// Update is called once per frame
	void Update () {
		//The following code takes input from <- -> keys on keyboard as well as joystick
		float xDirection = Input.GetAxisRaw("Horizontal");

		//The following code simply assignes a speed and a direction to "Vaus"
		GetComponent<Rigidbody2D>().velocity = Vector2.right * xDirection * speed * Time.deltaTime;

		//The following code spawns laser-shots
		if (Input.GetKeyDown (KeyCode.Space) && (powerUp == "Laser")) {
			Instantiate (LaserShotPrefab, laserSpawnPoint1.position,  Quaternion.identity);
			Instantiate (LaserShotPrefab, laserSpawnPoint2.position,  Quaternion.identity);
		}
	}

	//For getting the power-ups
	void OnCollisionEnter2D (Collision2D collision)	{
		if (collision.gameObject.tag == "powerup") {
			//audioSource.Play ();

			if (collision.gameObject.name == "LaserCapsule(Clone)") {

				if (powerUp == "Slow") {
					ball.SetBallSpeeed(300f);
				}

				animator.SetBool ("isLong", false);
				powerUp = "Laser";

			}  else if (collision.gameObject.name == "EnlargeCapsule(Clone)") {

				if (powerUp == "Slow") {
					ball.SetBallSpeeed(325f);
				}

				animator.SetBool ("isLong", true);
				powerUp = "Enlarge";


			}  else if ((collision.gameObject.name == "SlowCapsule(Clone)") && (powerUp != "Slow")) {
				animator.SetBool ("isLong", false);
				powerUp = "Slow";
				ball.SetBallSpeeed(150f);
			}

			//print(powerUp);
		}
	}

	public void DestroyVaus (){
		Destroy (gameObject, 0.1f);
	}
}

