﻿using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {
	public float moveSpeed = 4.0f;
	private Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	// Update is called once per frame
	void Update () {
		Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z) ;
		transform.LookAt (targetPosition);
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Bullet") {
			Destroy (gameObject);
		}
	}
}