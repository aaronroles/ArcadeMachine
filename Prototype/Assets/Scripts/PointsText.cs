using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointsText : MonoBehaviour {

	public static int pts;
	Text ptsText;

	// Use this for initialization
	void Start () {
		ptsText = GetComponent<Text> ();
		pts = 0;
	}
	
	// Update is called once per frame
	void Update () {
		ptsText.text = pts.ToString() + " points";

		//if (pts == 190) {
		//	TextHandler.text = "Level complete";
		//}
	}
}
