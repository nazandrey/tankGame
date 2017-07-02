using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {
	public float attackDamage = 4;

	private MonsterSpawner _monsterSpawner;
	private Health _health;

	void Start () {
		_monsterSpawner = GameObject.FindGameObjectWithTag ("GameController").GetComponent<MonsterSpawner> ();
		_health = gameObject.GetComponent<Health> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Shot") {
			Shot shot = other.gameObject.GetComponent<Shot> ();
			if (_health != null) {
				_health.Hurt (shot.damageOnHit);
				if (_health.IsDead) {
					_monsterSpawner.Spawn ();
				}
			}
		} else if (other.tag == "Player") {
			Health playerHealth = other.GetComponent<Health> ();
			if (playerHealth != null) {
				playerHealth.Hurt (attackDamage);
			}
			Destroy (gameObject);
			_monsterSpawner.Spawn ();
		}
	}
}
