using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpText : MonoBehaviour {

	static int currentScore;
	int currentHighscore;
	public static Text popUpText;

	// Use this for initialization
	void Start () {
		popUpText = GetComponent<Text> ();
		if(PlayerPrefs.HasKey("HighScore")){
			currentHighscore = PlayerPrefs.GetInt("HighScore");
			//print ("Got highscore " + currentHighscore);
		}
		else{
			// Otherwise, no high score
			PlayerPrefs.SetInt("HighScore", 0);
			currentHighscore = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		currentScore = PointsText.pts;
		popUpText.text = currentScore.ToString();

		if (currentScore > currentHighscore) {
			// The current high score is now score
			currentHighscore = currentScore;
			// Set the score to the high score key
			PlayerPrefs.SetInt("HighScore", currentScore);
			//PlayerPrefs.Save();
			//print ("new high score: " + currentHighscore);
		}
	}
}
