using UnityEngine;
using System.Collections;

public class ProjCollision : MonoBehaviour {

	void Update(){
		Destroy (gameObject, 2);
	}

	void OnCollisionEnter2D(Collision2D other){
		//if (other.gameObject.tag != "Enemy" && other.gameObject.tag != "HitBox") {
			Destroy (gameObject);
		//}
	}
}
