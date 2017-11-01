using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	//public static int finalScore;

	int score;
	int brickDestroyCount = 0;

	Text scoreCount;
	YouWin youWin;
	Ball ball;
	Vaus vaus;

	// Use this for initialization
	void Start () {
		
		scoreCount = gameObject.GetComponent<Text>();
		youWin = FindObjectOfType<YouWin>();
		ball = FindObjectOfType<Ball>();
		vaus = FindObjectOfType<Vaus>();
		score = 0;

	}

	public void IncreaseScore (int howMuchToAdd){
		score = score + howMuchToAdd;
		scoreCount.text = score.ToString();
		//finalScore = score;

	}

	public void BrickDead(){
		brickDestroyCount++;
		//print (brickDestroyCount);
		if (brickDestroyCount == 66) {
			youWin.DisplayYouWin();
			ball.DestroyBall ();
			vaus.DestroyVaus();
		}
	}

	public int tellmeCurrentScore(){
		return score;
	}

}
