using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	public static int collectCount;

	void Start(){
		collectCount = 0;
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			Destroy(gameObject);
			collectCount++;
			PointsText.pts += 25;
			//TextHandler.text = "Collected thing " + collectCount;
		}
	}
}
