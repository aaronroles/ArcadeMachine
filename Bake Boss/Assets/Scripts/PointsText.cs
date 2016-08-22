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

		//if(PlayerPrefs.HasKey("Score")){
		//	currentScore = PlayerPrefs.GetInt("Score");
		//}
		//else{
		//	// Otherwise, no high score
		//	PlayerPrefs.SetInt("Score", 0);
		//}

	}
	
	// Update is called once per frame
	void Update () {
		ptsText.text = pts.ToString() + " points";
		//currentScore = pts;
		//PlayerPrefs.SetInt("Score", pts);

		//if (pts == 190) {
		//	TextHandler.text = "Level complete";
		//}
	}
}
