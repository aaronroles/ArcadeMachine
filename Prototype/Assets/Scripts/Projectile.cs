using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	float delay = 2.5f;
	public GameObject projectile;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Fall", delay, delay);
	}
	
	// Update is called once per frame
	void Fall () {
		Instantiate (projectile, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-2, gameObject.transform.position.z), Quaternion.identity);
	}
}
