﻿using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {
	public float moveSpeed = 4;
	public float attackDamage = 4;
	public float health = 10;
	[Range(0f,1f)]public float armor = 0.5f;

	private Transform player;
	private MonsterSpawner monsterSpawner;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		monsterSpawner = GameObject.FindGameObjectWithTag ("GameController").GetComponent<MonsterSpawner> ();
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
			TakeDamage (shot.damageOnHit);
			if (health < 0) {
				Destroy (gameObject);
				monsterSpawner.Spawn ();
			}
		} else if (other.tag == "Player") {
			player.GetComponent<TankController>().TakeDamage (attackDamage);
			Destroy (gameObject);
			monsterSpawner.Spawn ();
		}
	}

	void TakeDamage(float damage){
		health -= damage * (1f - armor);
	}
}
