using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingPlayer : MonoBehaviour {
	public float moveSpeed = 4;

	private Transform _player;

	void Start () {
		_player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update () {
		if (_player != null) {
			Vector3 targetPosition = new Vector3 (_player.position.x, transform.position.y, _player.position.z);
			transform.LookAt (targetPosition);
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		}
	}
}
