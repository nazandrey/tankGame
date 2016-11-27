using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
	public float speed;
	public float maneuverability;
	public float health = 10;
	[Range(0f,1f)]public float armor = 0.5f;
	public WeaponController[] weapons;

	private WeaponController currentWeapon;

	// Use this for initialization
	void Start () {
		currentWeapon = weapons [0];
		currentWeapon.Activate();
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
			currentWeapon.Deactivate();
			if (Input.GetKey (KeyCode.Q)) {
				currentWeapon = weapons [0];
			} else if (Input.GetKey (KeyCode.W)) {
				currentWeapon = weapons [1];
			}
			currentWeapon.Activate();
		}

		if (Input.GetKey (KeyCode.X)) {
			currentWeapon.Shoot ();
		}
	}

	public void TakeDamage(float damage){
		health -= damage * (1f - armor);
	}
}
