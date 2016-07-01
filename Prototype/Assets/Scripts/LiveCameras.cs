/* using UnityEngine;
using System.Collections;
public class LiveCameras : MonoBehaviour {

	public LiveCameras camera1;
	public LiveCameras camera2;
	public Camera liveCam;
	public GameObject player;
	private Transform playerPos;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerPos = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y > 0 && player.transform.position.y < 10) {
			print("Cam 1");
			Camera.camera1.enabled = true;
			Camera.camera2.enabled = false;
		}
		if (player.transform.position.y > 10) {
			print("Cam 2");
			Camera.camera1.enabled = false;
			Camera.camera2.enabled = true;
		}
	}
}
*/