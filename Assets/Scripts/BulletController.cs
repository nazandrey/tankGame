using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	private const float DefaultBulletDestroyingTime = 3.0f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, DefaultBulletDestroyingTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter() {
		Destroy (gameObject);
	}

	void OnTriggerEnter() {
		Destroy (gameObject);
	}
}
