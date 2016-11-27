﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {
	public List<SpawnPointController> spawnPointList;
	public GameObject[] monsterTypeArr;
	private const int MonsterCount = 10;
	private List<SpawnPointController> activeSpawnPointList;

	// Use this for initialization
	void Start () {
		checkActiveSpawnPointList ();
		for (int i = 0; i < MonsterCount; i++) {
			Spawn ();
		}
		InvokeRepeating ("checkActiveSpawnPointList",0.5f,0.5f);
	}

	public void checkActiveSpawnPointList(){
		activeSpawnPointList = new List<SpawnPointController>();
		for (int i = 0; i < spawnPointList.Count; i++) {
			SpawnPointController spawnPoint = spawnPointList [i];
			if (spawnPoint.isActive) {
				activeSpawnPointList.Add(spawnPoint);
			}
		}
	}

	public void Spawn(){		
		int spawnPointIndex = Random.Range (0, activeSpawnPointList.Count);
		int monsterTypeIndex = Random.Range (0, monsterTypeArr.Length);
		activeSpawnPointList[spawnPointIndex].Spawn(monsterTypeArr [monsterTypeIndex]);
		activeSpawnPointList.RemoveAt (spawnPointIndex);	
	}
}
