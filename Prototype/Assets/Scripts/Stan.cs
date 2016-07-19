using UnityEngine;
using System.Collections;

public class Stan : MonoBehaviour {
	
	float speed = 15f;
	float jump = 75f;
	bool grounded;
	bool moving;
	Animator animator;
	BoxCollider2D box;
	Vector2 original;
	Vector2 bounds;

	//public Vector2 maxVelocity = new Vector2(3,3);

	void Start(){
		animator = GetComponent<Animator>();
		box = GetComponent<BoxCollider2D> ();
		original = new Vector2 (1.2f, 3.39f);
	}
	
	// Update is called once per frame
	void Update () {

		bounds = renderer.bounds.size;

		// Right, Left, Idle
		if (Input.GetKey (KeyCode.D)) {
			rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);
			transform.localScale = new Vector3 (1, 1, 1);
			animator.SetInteger ("AnimState", 1);
			moving = true;
			TextHandler.text = "Moving right";
		} 

		else if (Input.GetKey (KeyCode.A)) {
			rigidbody2D.velocity = new Vector2 (-speed, rigidbody2D.velocity.y);
			transform.localScale = new Vector3 (-1, 1, 1);
			animator.SetInteger ("AnimState", 1);
			moving = true;
			TextHandler.text = "Moving left";
		} 

		else {
			animator.SetInteger("AnimState", 0);
			moving = false;
		}

		// Jump, Crouch, Crawl
		if (Input.GetKey (KeyCode.W) && grounded) {
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, jump);
			animator.SetInteger ("AnimState", 2);
			TextHandler.text = "Jumping";
		} 

		else if (Input.GetKey (KeyCode.S) && !moving) {
			animator.SetInteger ("AnimState", 3);
			box.size = bounds;
			TextHandler.text = "Crouching";
		} 

		else if (Input.GetKey (KeyCode.S) && moving) {
			animator.SetInteger ("AnimState", 4);
			box.size = bounds;
			TextHandler.text = "Crawling";
		} 

		else if(Input.GetKeyUp(KeyCode.S)){
			animator.SetInteger("AnimState", 6);
			box.size = bounds;
			TextHandler.text = "Standing Up";
		}

		else {
			moving = false;
			box.size = original;
		}
	}

	// Collision Detection

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Ground" | other.gameObject.tag == "Obstacle") {
			grounded = true;
			TextHandler.text = "Grounded";
		} 
		else if (other.gameObject.tag == "Enemy" | other.gameObject.tag == "Respawn" | other.gameObject.tag == "Deadly") {
			TextHandler.text = "RELOADING";
			Application.LoadLevel (Application.loadedLevel);
		} 
	}

	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag == "Ground" | other.gameObject.tag == "Obstacle") {
			grounded = true; 
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag == "Ground" | other.gameObject.tag == "Obstacle") {
			grounded = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "HitBox") {
			TextHandler.text = "Enemy killed";
			PointsText.pts += 10;
			Destroy(other.transform.parent.gameObject);
		}

	}
}

