﻿using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {
	public GameObject shotTemplate;

	private float DelayBetweenShots;
	private float ShotStartDistance;
	private float currentDelayBetweenShots = 0.0f;
	private bool canShoot = true;

	public WeaponController(float delayBetweenShots, float shotStartDistance){
		DelayBetweenShots = delayBetweenShots;
		ShotStartDistance = shotStartDistance;
	}

	// Update is called once per frame
	void Update () {
		if (currentDelayBetweenShots > 0) {
			canShoot = false;
			currentDelayBetweenShots -= Time.deltaTime;
		} else {
			canShoot = true;
		}
	}

	public void Shoot(){
		if (canShoot) {
			Vector3 shotPosition = gameObject.transform.position + gameObject.transform.forward * ShotStartDistance;
			Instantiate (shotTemplate, shotPosition, gameObject.transform.rotation);
			currentDelayBetweenShots = DelayBetweenShots;
		}
	}

	public void Activate () {
		GetComponent<Renderer>().material.color = Color.red;
	}

	public void Deactivate () {
		GetComponent<Renderer>().material.color = Color.yellow;
	}
}
