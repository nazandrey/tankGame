using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
	public float defaultBulletDestroyingTime;
	public float damageOnHit;

	public Shot(float time, float damage){
		defaultBulletDestroyingTime = time;
		damageOnHit = damage;
	}

	void Start () {
		Destroy (gameObject, defaultBulletDestroyingTime);
	}

	void OnTriggerEnter() {
		Destroy (gameObject);
	}
}
