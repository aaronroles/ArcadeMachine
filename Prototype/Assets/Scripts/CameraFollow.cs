using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public GameObject target;
	private Transform playerPos;
	
	// Use this for initialization
	void Start () {
		playerPos = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
		// Changed from following the player's y position to staying at the camera's y position
		transform.position = new Vector3 (playerPos.position.x, transform.position.y, transform.position.z);
	}
}