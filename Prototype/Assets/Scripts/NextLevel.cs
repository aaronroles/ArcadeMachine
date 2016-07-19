using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public string levelToLoad;

	// Use this for initialization
	void OnCollisionEnter2D(Collision2D player){
		if (player.gameObject.tag == "Player") {
			TextHandler.text = "Loading level: " + levelToLoad;
			Application.LoadLevel(levelToLoad);
		}
	}
}
