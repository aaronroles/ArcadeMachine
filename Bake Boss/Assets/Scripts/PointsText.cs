using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointsText : MonoBehaviour {

	public static int pts;
	Text ptsText;
	int currentScore;

	// Use this for initialization
	void Start () {
		ptsText = GetComponent<Text> ();
		pts = 0;

		if(PlayerPrefs.HasKey("Score")){
			currentScore = PlayerPrefs.GetInt("HighScore");
		}
		else{
			//Otherwise, no high score
			PlayerPrefs.SetInt("HighScore", 0);
		}

	}
	
	// Update is called once per frame
	void Update () {
		ptsText.text = "SCORE:" + pts.ToString();
		currentScore = pts;
		PlayerPrefs.SetInt("HighScore", currentScore);

		//if (pts == 190) {
		//	TextHandler.text = "Level complete";
		//}
	}
}
