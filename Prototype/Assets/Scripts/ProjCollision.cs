using UnityEngine;
using System.Collections;

public class ProjCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other){
		Destroy (gameObject);
	}
}
