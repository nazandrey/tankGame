using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
	public float speed;
	public float maneuverability;
	public CannonController cannon;
	public MachineGunController machineGun;

	// Use this for initialization
	void Start () {
	
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

		if (Input.GetKey (KeyCode.X)) {
			cannon.Shoot ();
			machineGun.Shoot ();
		}
	}
}
