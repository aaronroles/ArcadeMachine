using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class CookieProjectile : MonoBehaviour {

	Animator animator;
	AudioSource audio;

	public AudioClip cookieSpitSFX;
	public GameObject projectile;
	public Transform projSpawn;
	
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		animator = GetComponent<Animator> ();
		Fire ();
	}
	
	public void Fire() {
		animator.SetTrigger ("Fire");
		audio.PlayOneShot (cookieSpitSFX);

		if (gameObject.transform.localScale.x == -1) {
			Instantiate (projectile, projSpawn.position, Quaternion.Euler(new Vector3(0,0,0)));
		}
		else if (gameObject.transform.localScale.x == 1) {
			Instantiate (projectile, projSpawn.position, Quaternion.Euler(new Vector3(0,0,180f)));
		}
	}
}
