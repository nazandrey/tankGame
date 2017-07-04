using UnityEngine;
using System.Collections;

public class GunShooter : MonoBehaviour {
	public GameObject shotTemplate;

	private float _delayBetweenShots;
	private float _shotStartDistance;
	private float _currentDelayBetweenShots = 0.0f;
	private bool _canShoot = true;

	public GunShooter(float delayBetweenShots, float shotStartDistance){
		_delayBetweenShots = delayBetweenShots;
		_shotStartDistance = shotStartDistance;
	}

	void Update () {
		if (_currentDelayBetweenShots > 0) {
			_canShoot = false;
			_currentDelayBetweenShots -= Time.deltaTime;
		} else {
			_canShoot = true;
		}
	}

	public void Shoot(){
		if (_canShoot) {
			Vector3 shotPosition = gameObject.transform.position + gameObject.transform.forward * _shotStartDistance;
			Instantiate (shotTemplate, shotPosition, gameObject.transform.rotation);
			_currentDelayBetweenShots = _delayBetweenShots;
		}
	}

	public void Activate () {
		GetComponent<Renderer>().material.color = Color.red;
	}

	public void Deactivate () {
		GetComponent<Renderer>().material.color = Color.yellow;
	}
}
