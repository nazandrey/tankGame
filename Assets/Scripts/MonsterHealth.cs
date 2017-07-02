using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : Health {
	private MonsterSpawner _monsterSpawner;

	void Start(){
		_monsterSpawner = GameObject.FindGameObjectWithTag ("GameController").GetComponent<MonsterSpawner> ();
	}

	protected override void _OnDeath(){
		_monsterSpawner.Spawn ();
		base._OnDeath ();
	}
}
