using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MuffinExplode : MonoBehaviour {

	public GameObject blastZone;
	public AudioClip muffinExplodeSFX;

	private Vector3 player;
	private Vector2 playerDirection;
	private float xDiff;
	private float yDiff;
	private float distance;

	Animator anim;
	AudioSource audio;
	EnemyPath enemyPath;

	// Use this for initialization
	void Start () {
		blastZone.SetActive (false);
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
		enemyPath = GetComponent<EnemyPath> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (GameObject.FindWithTag ("Player")) {
			player = GameObject.FindWithTag ("Player").transform.position;
			xDiff = player.x - transform.position.x;
			yDiff = player.y - transform.position.y;
			playerDirection = new Vector2 (xDiff, yDiff);
			distance = Vector2.Distance (player, transform.position);
		}

		if (distance < 3) {
			enemyPath.speed = 0;
			anim.SetTrigger("Explode");
		}
	}

	void Blast(){
		blastZone.SetActive(true);
		audio.PlayOneShot (muffinExplodeSFX);
		Destroy(gameObject, 1);
	}
}
