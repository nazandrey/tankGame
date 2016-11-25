using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
	public float speed;
	public float maneuverability;
	public CannonController cannon;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			gameObject.transform.Translate (new Vector3 (0, 0, speed));
		} 

		if (Input.GetKey (KeyCode.S)) {
			gameObject.transform.Translate (new Vector3 (0, 0, -speed));
		}

		if (Input.GetKey (KeyCode.A)) {
			gameObject.transform.Rotate(new Vector3 (0, -maneuverability, 0));
		} 

		if (Input.GetKey (KeyCode.D)) {
			gameObject.transform.Rotate(new Vector3 (0, maneuverability, 0));
		}

		if (Input.GetKey (KeyCode.X)) {
			cannon.Shoot ();
		}
	}
}
