using UnityEngine;
using System.Collections;

public class Stan : MonoBehaviour {
	
	float speed = 15f;
	float jump = 75f;
	bool grounded;

	public Vector2 maxVelocity = new Vector2(3,3);

	void Start(){
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("right")) {
			rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
			transform.localScale = new Vector3(1,1,1);
			TextHandler.text = "Moving right";
		} 
		else if (Input.GetKey ("left")) {
			rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
			transform.localScale = new Vector3(-1,1,1);
			TextHandler.text = "Moving left";
		}
		if (Input.GetKeyDown ("up") && grounded) {
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.y, jump);
			TextHandler.text = "Jumping";
		} 
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Ground" | other.gameObject.tag == "Obstacle") {
			grounded = true;
			TextHandler.text = "Grounded";
		} 
		else if (other.gameObject.tag == "Enemy") {
			TextHandler.text = "You should be dead";
		} 
		else if (other.gameObject.tag == "Respawn") {
			TextHandler.text = "RELOADING";
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag == "Ground" | other.gameObject.tag == "Obstacle") {
			grounded = true; 
		}
		else if (other.gameObject.tag == "Enemy") {
			TextHandler.text = "You should be dead";
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag == "Ground" | other.gameObject.tag == "Obstacle") {
			grounded = false;
		}
	}
}

