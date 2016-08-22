﻿using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public string levelToLoad;
	public GameObject scoreCanvas;

	float countdown = 3f;

	bool readyToLoadLevel = false;

	void Update(){
		if (readyToLoadLevel) {
			countdown -= Time.deltaTime;
			if (countdown <= 0) {
				countdown = 0;
				LoadNextLevel ();
			}
		}
	}

	void OnCollisionEnter2D(Collision2D player){

		if (player.gameObject.tag == "Player") {
			TextHandler.text = "Loading level: " + levelToLoad;
			readyToLoadLevel = true;
			Physics2D.IgnoreCollision(gameObject.collider2D, player.collider);
			scoreCanvas.SetActive(true);
		}
	}

	void LoadNextLevel(){
		Application.LoadLevel(levelToLoad);
	}
}
