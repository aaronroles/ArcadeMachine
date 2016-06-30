using UnityEngine;
using System.Collections;

public class EnemyPath : MonoBehaviour {

	public float speed = 5f;
	public Transform sightStart, sightEnd;
	private bool collision = false;
	public bool needsCollision = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Move the enemy
		rigidbody2D.velocity = new Vector2 (transform.localScale.x, 0) * speed;
		// Detect collision with solids
		collision = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer ("Solid"));
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);

		if (collision == needsCollision) {
			this.transform.localScale = new Vector3((transform.localScale.x == 1) ? -1 : 1, 1, 1);
		}
	}
}
