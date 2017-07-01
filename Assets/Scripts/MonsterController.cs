using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {
	public float moveSpeed = 4;
	public float attackDamage = 4;

	private Transform player;
	private MonsterSpawner monsterSpawner;
	private Health health;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		monsterSpawner = GameObject.FindGameObjectWithTag ("GameController").GetComponent<MonsterSpawner> ();
		health = gameObject.GetComponent<Health> ();
	}

	// Update is called once per frame
	void Update () {
		Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z) ;
		transform.LookAt (targetPosition);
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Shot") {
			Shot shot = other.gameObject.GetComponent<Shot> ();
			if (health != null) {
				health.Hurt (shot.damageOnHit);
				if (health.IsDead) {
					monsterSpawner.Spawn ();
				}
			}
		} else if (other.tag == "Player") {
			Health playerHealth = player.GetComponent<Health> ();
			if (playerHealth != null) {
				playerHealth.Hurt (attackDamage);
			}
			Destroy (gameObject);
			monsterSpawner.Spawn ();
		}
	}
}
