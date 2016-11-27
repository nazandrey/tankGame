using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {
	public float moveSpeed = 4;
	private Transform player;
	private float attackDamage = 4;
	public float health = 10;
	[Range(0f,1f)]public float armor = 0.5f;

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
		if (other.tag == "Shot") {
			ShotController shot = other.gameObject.GetComponent<ShotController> ();
			TakeDamage (shot.damageOnHit);
			if (health < 0) {
				Destroy (gameObject);
			}
		} else if (other.tag == "Player") {
			player.GetComponent<TankController>().TakeDamage (attackDamage);
			Destroy (gameObject);
		}
	}

	void TakeDamage(float damage){
		health -= damage * (1f - armor);
	}
}
