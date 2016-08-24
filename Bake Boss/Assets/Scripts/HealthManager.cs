using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

	public static int health = 3;
	public GameObject life1;
	public GameObject life2;
	public GameObject life3;

	// Use this for initialization
	void Start () {
		health = 3;
		life1.SetActive(true);
		life2.SetActive(true);
		life3.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

		if (health == 3) {
			life1.SetActive(true);
			life2.SetActive(true);
			life3.SetActive(true);
		}

		if (health == 2) {
			life1.SetActive(false);
			life2.SetActive(true);
			life3.SetActive(true);
		}

		if (health == 1) {
			life1.SetActive(false);
			life2.SetActive(false);
			life3.SetActive(true);
		}

		if (health <= 0) {
			life1.SetActive(false);
			life2.SetActive(false);
			life3.SetActive(false);
		}
	}
}
