using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {
	public float defaultBulletDestroyingTime;
	public float damageOnHit;

	public ShotController(float time, float damage){
		defaultBulletDestroyingTime = time;
		damageOnHit = damage;
	}

	// Use this for initialization
	void Start () {
		Destroy (gameObject, defaultBulletDestroyingTime);
	}

	void OnCollisionEnter() {
		Destroy (gameObject);
	}

	void OnTriggerEnter() {
		Destroy (gameObject);
	}
}
