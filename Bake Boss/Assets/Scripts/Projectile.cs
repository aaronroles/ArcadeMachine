using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	float startDelay;
	float delay;
	public GameObject projectile;

	// Use this for initialization
	void Start () {
		startDelay = Random.Range (1, 5);
		delay = Random.Range (2, 5);

		if (this.gameObject.name == "FallingProjectile") {
			InvokeRepeating ("Fall", startDelay, delay);
		}
	}
	
	// Update is called once per frame
	void Fall () {
		Instantiate (projectile, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-2, gameObject.transform.position.z), Quaternion.identity);
	}
}
