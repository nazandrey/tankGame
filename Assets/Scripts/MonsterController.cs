using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {
	public float attackDamage = 4;

	private Health _health;

	void Start () {
		_health = gameObject.GetComponent<Health> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Shot") {
			Shot shot = other.gameObject.GetComponent<Shot> ();
			if (_health != null) {
				_health.Hurt (shot.damageOnHit);
			}
		} else if (other.tag == "Player") {
			Health playerHealth = other.GetComponent<Health> ();
			if (playerHealth != null) {
				playerHealth.Hurt (attackDamage);
			}
			Destroy (gameObject);
			//_monsterSpawner.Spawn ();
		}
	}
}
