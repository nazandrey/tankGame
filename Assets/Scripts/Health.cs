using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public float health = 10;
	[Range(0f,1f)]public float armor = 0.5f;

	public void Hurt(float damage){
		health -= damage * (1f - armor);
		if (health < 0) {
			Destroy (gameObject);
		}
	}

	public bool IsDead {
		get
		{
			return health < 0;
		}
	}
}
