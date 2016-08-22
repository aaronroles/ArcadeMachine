using UnityEngine;
using System.Collections;

public class FallingBlock : MonoBehaviour {

	Rigidbody2D rb2d;

	void Start(){
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	void Update(){
		if (this.transform.position.y <= -10) {
			Destroy (this.gameObject);
		}
	}

	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			rb2d.velocity = new Vector2(0, -10);
		}
	}
}