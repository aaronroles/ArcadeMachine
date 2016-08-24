using UnityEngine;
using System.Collections;

public class BakeBoss : MonoBehaviour {

	Animator anim;
	public Transform[] points;
	float timeToWait;
	float timer;
	float speed;
	int bossHealth;
	int randomPt;

	// Use this for initialization
	void Start () {
		timer = 0;
		timeToWait = 1.5f;
		speed = 1;
		bossHealth = 3;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (timer >= timeToWait) {
			timer = 0;
			randomPt = Random.Range(0, points.Length);
			gameObject.collider2D.enabled = true;
			//print(randomPt);
			//gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, points[randomPt].transform.position, 1);
		}

		gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, points[randomPt].transform.position, speed);
		timer += Time.deltaTime;

		if (bossHealth == 2) {
			anim.SetInteger("Health", 2);
			speed = 2;
		}

		if (bossHealth == 1) {
			anim.SetInteger("Health", 1);
			speed = 3;
		}

		if (bossHealth == 0) {
			gameObject.collider2D.enabled = false;
			speed = 10;
			Destroy(gameObject, 3);
			//TextHandler.text = "YOU BEAT BOSS";
			PointsText.pts += 25;
		}
	}

	public void Damage(int damage){
		bossHealth -= damage;
		print (bossHealth);
	}
}
