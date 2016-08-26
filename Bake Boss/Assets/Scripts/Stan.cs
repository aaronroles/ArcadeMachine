using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Stan : MonoBehaviour {
	
	float countdown = 10f;
	float speed = 15f;
	float jump = 75f;
	float bounce = 100f;
	float direction;

	bool grounded;
	bool moving;
	bool dead;
	bool crouching;
	bool jumping;
	bool doublePts;

	Animator animator;
	AudioSource audio;
	BoxCollider2D box;
	BoxCollider2D platformBox;

	Vector2 original;
	Vector2 bounds;
	Vector2 deathPos;

	public GameObject continueBtn;
	public GameObject countdownText;

	public AudioClip jumpSFX;
	public AudioClip doubleJumpSFX;
	public AudioClip takeDamageSFX;
	public AudioClip deadSFX;
	public AudioClip collectableSFX;
	public AudioClip finishSFX;

	void Start(){
		animator = GetComponent<Animator>();
		audio = GetComponent<AudioSource> ();
		box = GetComponent<BoxCollider2D> ();
		platformBox = GetComponentInChildren<BoxCollider2D> ();
		original = new Vector2 (1.2f, 3.39f);
		doublePts = dead = false;
	}
	
	// Update is called once per frame
	void Update () {
		direction = this.gameObject.transform.localScale.x;
		bounds = renderer.bounds.size;
		animator.SetInteger ("AnimState", 0);

		if (!dead) {
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
				moving = false;
			}

			// Jump, Crouch, Crawl
			if (Input.GetKeyDown (KeyCode.W) && grounded && !crouching) {
				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, jump);
				grounded = false;
				jumping = true;
				animator.SetBool("Grounded", false);
				animator.SetInteger ("AnimState", 2);
				platformBox.size = bounds;
				box.size = bounds;
				TextHandler.text = "Jumping";
				audio.PlayOneShot(jumpSFX);
			} 

			else if (Input.GetKey (KeyCode.S) && !moving) {
				animator.SetInteger ("AnimState", 3);
				box.size = bounds;
				TextHandler.text = "Crouching";
				crouching = true;
			} 

			else if (Input.GetKey (KeyCode.S) && moving) {
				animator.SetInteger ("AnimState", 4);
				box.size = bounds;
				TextHandler.text = "Crawling";
				crouching = true;
			} 

			else if (Input.GetKeyUp (KeyCode.S)) {
				animator.SetInteger ("AnimState", 6);
				box.size = bounds;
				crouching = false;
				TextHandler.text = "Standing Up";
			} 

			else if (Input.GetKeyUp (KeyCode.W)) {
				jumping = false;
			} 

			else {
				moving = false;
				box.size = original;
			}

			if (crouching) {
				box.size = bounds;
			} 

		} 

		else if (dead) {
			TextHandler.text = Mathf.Round((countdown*10)/10).ToString();
			countdownText.SetActive(true);
			continueBtn.SetActive(true);
			animator.SetInteger("AnimState", 5);
			box.size = bounds;
			countdown -= Time.deltaTime;
			if (countdown <= 0){
				countdown = 0;
				Application.Quit ();
			}
		}
	}

	// Collision Detection

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Collision") {
			grounded = true;
			animator.SetBool ("Grounded", true);
			TextHandler.text = "Grounded";
			doublePts = false;
		} 

		else if (other.gameObject.tag == "Enemy" | other.gameObject.tag == "Projectile" || other.gameObject.tag == "BakeBoss") {
			if (HealthManager.health > 0) {
				if (gameObject.transform.localScale.x == 1) {
					rigidbody2D.AddForce (new Vector2 (-100, 10), ForceMode2D.Impulse);
				} else if (gameObject.transform.localScale.x == -1) {
					rigidbody2D.AddForce (new Vector2 (100, 10), ForceMode2D.Impulse);
				}
				HealthManager.health -= 1;
				audio.PlayOneShot(takeDamageSFX);
			}

			if (HealthManager.health <= 0) {
				dead = true;
				animator.SetBool ("Grounded", true);
			}	
		} 

		else if (other.gameObject.tag == "Respawn" | other.gameObject.tag == "Deadly") {
			HealthManager.health = 0;
			dead = true;
		} 

		if (other.gameObject.tag == "Dead") {
			Physics2D.IgnoreCollision(gameObject.collider2D, other.collider);
		}

		if (other.gameObject.tag == "Collectable") {
			audio.PlayOneShot(collectableSFX);
		}

		if (other.gameObject.tag == "Finish") {
			audio.PlayOneShot(finishSFX);
		}
	}

	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag == "Ground") {
			rigidbody2D.velocity = new Vector2 (0, -10);
		} 
	}

	//void OnCollisionExit2D(Collision2D other){
	//	if (other.gameObject.tag == "Collision") {
	//		grounded = false;
	//		animator.SetBool ("Grounded", false);
	//	} 
	//}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "HitBox") {
			if(!doublePts){
				TextHandler.text = "Enemy killed (+10)";
				PointsText.pts += 10;
				doublePts = true;
				audio.PlayOneShot(jumpSFX);
			}
			else if(doublePts){
				TextHandler.text = "Enemy killed (+20)";
				PointsText.pts += 20;
				audio.PlayOneShot(doubleJumpSFX);
			}

			other.gameObject.tag = "Dead";
			other.transform.parent.GetComponent<EnemyPath>().dead = true;
			other.transform.parent.GetComponent<Animator>().SetTrigger("Dead");
			rigidbody2D.velocity = new Vector2 (0, bounce);
			Destroy (other.transform.parent.gameObject, 2);
		}

		if (other.gameObject.tag == "BlastZone") {
			HealthManager.health -= 1;
			animator.SetBool ("Grounded", false);
			rigidbody2D.AddForce (new Vector2 ((-direction * 100), 50), ForceMode2D.Impulse);
		}

		if (other.gameObject.tag == "BossHitBox") {
			rigidbody2D.velocity = new Vector2 (0, bounce*(Random.Range(1,2)));
			other.gameObject.transform.parent.GetComponent<BakeBoss>().Damage(1);
		}

		if (other.gameObject.tag == "MaxHealth") {
			HealthManager.health = 3;
		}

	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "CrouchArea") {
			TextHandler.text = "Entered crawl space";
			animator.SetBool("CrawlSpace", true);
			crouching = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "CrouchArea") {
			TextHandler.text = "Exited crawl space";
			animator.SetBool("CrawlSpace", false);
			crouching = false;
		}
	}

	public void Continue(){
		Application.LoadLevel (Application.loadedLevel);
		TextHandler.text = "RELOADING";
	}

	public void PlayDeadSFX(){
		audio.PlayOneShot(deadSFX);
	}
}

