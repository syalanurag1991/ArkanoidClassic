using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	float speed = 310f;
	public int brickHitCount = 0;
	Vector2 reflector;
	Transform vausTransform;
	Vector3 ballPosition;
	bool ballMoving = false;

	void Start () {
		//This code launches the ball in upward direction in start of the level after a delay
		StartCoroutine(MyMethod());
		vausTransform = FindObjectOfType<Vaus>().transform;
	}

	void Update ()	{
		if (!ballMoving) {
			gameObject.transform.position = vausTransform.position + new Vector3 (0.45f, 0.3f);
		}
	}

	Vector2 CalculateReflectVector (Vector2 vausPosition, Vector2 ballPosition, float vausWidth) {
		//This code calculates and normalizes the x-position of the impact of ball wrt Vaus, ranges from -1 to 1
		float xHitPositionOnVaus = (vausPosition.x - ballPosition.x)/vausWidth;
		//The reflection vector is given by:
		//Reflection = (-1 * Position of impact, 1)
		//Ball is always reflected with a unit velocity in y-direction
		//This code simply converts the impact position returns the 
			Vector2 newDirection =  new Vector2 (-xHitPositionOnVaus, Mathf.Sqrt(1- xHitPositionOnVaus*xHitPositionOnVaus));
		//Vector2 newDirection =  new Vector2 (-xHitPositionOnVaus, 1).normalized;
		return newDirection;
	}

	void OnCollisionEnter2D (Collision2D ballcollision)
	{

		//When ball collides with Vaus
		if (ballcollision.gameObject.name == "Vaus") {
			//This code calculates the position of object the ball colldes with, in this case it is Vaus
			Vector2 vausPosition = ballcollision.transform.position;
			//The function CalculateReflectVector is called
			//The code "ballcollider.collider" returns the collider with which the ball has collided with, in this case it is Vaus's collider
			//Hence, the extension ".bounds.size.x" returns the x-size of Vaus's collider in
			reflector = CalculateReflectVector (vausPosition, gameObject.transform.position, ballcollision.collider.bounds.size.x);
			GetComponent<Rigidbody2D> ().velocity = reflector * speed * Time.deltaTime;
		}

		//When ball collides with a brick, we count number of bricks and increase play speed accordingly
		if (ballcollision.gameObject.tag == "brick") {
			//scoreManager.BrickDead ();

			if (brickHitCount%5 == 0) {
				ChangeBallSpeed (1.01f);
			}
		}
	}

	public void ChangeBallSpeed (float multiplier) {
		speed = speed * multiplier;
	}

	public void SetBallSpeeed (float newSpeed) {
		speed = newSpeed;
		Vector2 normalizedVelocity = GetComponent<Rigidbody2D> ().velocity.normalized;
		GetComponent<Rigidbody2D> ().velocity = normalizedVelocity * speed * Time.deltaTime;
	}
		
	public void DestroyBall() {
		Destroy (gameObject, 0.1f);
	}

	IEnumerator MyMethod() {
		yield return new WaitForSeconds(0);
		GetComponent<Rigidbody2D>().velocity = Vector2.up * 0* Time.deltaTime;
		//yield return new WaitForSeconds(2f);
		while (!Input.GetKeyDown(KeyCode.Space))
			yield return new WaitForSeconds(0.01f);
		ballMoving = true;
		GetComponent<Rigidbody2D>().velocity = new Vector2 (speed/1.414f * Time.deltaTime, speed * Time.deltaTime) ;
 	}

}
