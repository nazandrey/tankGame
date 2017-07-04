using UnityEngine;
using System.Collections;

public class TankUserInput : MonoBehaviour {
	public float speed;
	public float maneuverability;
	public GunShooter[] gunArr;

	private GunShooter _currentGun;

	void Start () {
		_currentGun = gunArr [0];
		_currentGun.Activate();
	}

	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			gameObject.transform.Translate (new Vector3 (0, 0, speed));
		} 

		if (Input.GetKey (KeyCode.DownArrow)) {
			gameObject.transform.Translate (new Vector3 (0, 0, -speed));
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			gameObject.transform.Rotate(new Vector3 (0, -maneuverability, 0));
		} 

		if (Input.GetKey (KeyCode.RightArrow)) {
			gameObject.transform.Rotate(new Vector3 (0, maneuverability, 0));
		}

		if (Input.GetKey (KeyCode.Q) || Input.GetKey (KeyCode.W)) {
			_currentGun.Deactivate();
			if (Input.GetKey (KeyCode.Q)) {
				_currentGun = gunArr [0];
			} else if (Input.GetKey (KeyCode.W)) {
				_currentGun = gunArr [1];
			}
			_currentGun.Activate();
		}

		if (Input.GetKey (KeyCode.X)) {
			_currentGun.Shoot ();
		}
	}
}
