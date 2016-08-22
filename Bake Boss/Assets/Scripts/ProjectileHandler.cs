using UnityEngine;
using System.Collections;

public class ProjectileHandler : MonoBehaviour {

	Rigidbody2D rigidbody;
	public float fireSpeed = 15;

	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();

		if (transform.localRotation.z > 0) {
			rigidbody.AddForce (new Vector2 (1, 0) * fireSpeed, ForceMode2D.Impulse);
		} 
		else {
			rigidbody.AddForce (new Vector2 (-1, 0) * fireSpeed, ForceMode2D.Impulse);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
