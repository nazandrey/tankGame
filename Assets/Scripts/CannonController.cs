using UnityEngine;
using System.Collections;

public class CannonController : MonoBehaviour {
	public GameObject bulletTemplate;

	private const float DelayBetweenShots = 1.0f;
	private const int BulletStartDistance = 3;
	private float currentDelayBetweenShots = 0.0f;
	private bool canShoot = true;

	public void Shoot(){
		//debounce
		if (canShoot) {
			Vector3 bulletPosition = gameObject.transform.position + gameObject.transform.forward * BulletStartDistance;
			Instantiate (bulletTemplate, bulletPosition, gameObject.transform.rotation);
			currentDelayBetweenShots = DelayBetweenShots;
		}
	}

	// Use this for initialization
	void Start () {

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
}
