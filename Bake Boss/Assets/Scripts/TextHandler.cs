using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextHandler : MonoBehaviour {

	public static string text;
	Text onScreenText;
	int currentHighscore;

	// Use this for initialization
	void Start () {
		onScreenText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		onScreenText.text = text;

		if (Input.GetKeyDown (KeyCode.Space)) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
