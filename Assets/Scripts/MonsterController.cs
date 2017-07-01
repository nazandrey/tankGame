using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {
	public float moveSpeed = 4;
	public float attackDamage = 4;

	private Transform _player;
	private MonsterSpawner _monsterSpawner;
	private Health _health;


	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag ("Player").transform;
		_monsterSpawner = GameObject.FindGameObjectWithTag ("GameController").GetComponent<MonsterSpawner> ();
		_health = gameObject.GetComponent<Health> ();
	}

	// Update is called once per frame
	void Update () {
		Vector3 targetPosition = new Vector3(_player.position.x, transform.position.y, _player.position.z) ;
		transform.LookAt (targetPosition);
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
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
			Health playerHealth = _player.GetComponent<Health> ();
			if (playerHealth != null) {
				playerHealth.Hurt (attackDamage);
			}
			Destroy (gameObject);
			_monsterSpawner.Spawn ();
		}
	}
}
