using UnityEngine;
using System.Collections;

public class HurtPlayerOnHit : MonoBehaviour {
	public float attackDamage = 4;

	private Health _health;

	void Start () {
		_health = gameObject.GetComponent<Health> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Health playerHealth = other.GetComponent<Health> ();
			if (playerHealth != null) {
				playerHealth.Hurt (attackDamage);
			}
			Destroy (gameObject);
		}
	}
}
