using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
	public float speed;
	public float maneuverability;
	public WeaponController[] weapons;

	private WeaponController _currentWeapon;

	// Use this for initialization
	void Start () {
		_currentWeapon = weapons [0];
		_currentWeapon.Activate();
	}

	// Update is called once per frame
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
			_currentWeapon.Deactivate();
			if (Input.GetKey (KeyCode.Q)) {
				_currentWeapon = weapons [0];
			} else if (Input.GetKey (KeyCode.W)) {
				_currentWeapon = weapons [1];
			}
			_currentWeapon.Activate();
		}

		if (Input.GetKey (KeyCode.X)) {
			_currentWeapon.Shoot ();
		}
	}
}
