using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
	public float defaultBulletDestroyingTime;
	public float damageOnHit;

	public Shot(float time, float damage){
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
