using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScoreManager : MonoBehaviour {

	Text HighScoreNumber;
	int currentScore;
	int highScore;
	ScoreManager scoreManager;
	//int mostRecent;


	// Use this for initialization
	void Start () {
		HighScoreNumber = gameObject.GetComponent<Text> ();
		scoreManager = FindObjectOfType<ScoreManager> ();

		highScore = PlayerPrefs.GetInt("highScore", highScore);
		HighScoreNumber.text = highScore.ToString ();
	}
	
	// Update is called once per frame
	void Update () {

		currentScore = scoreManager.tellmeCurrentScore();
		if (currentScore > highScore) {
			highScore = currentScore;
			HighScoreNumber.text = highScore.ToString ();
			PlayerPrefs.SetInt("highScore", highScore);
		} 
	}
}




								    
