using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterSpawner : MonoBehaviour {
	public List<SpawnPoint> spawnPointList;
	public GameObject[] monsterTypeArr;

	private const int MonsterCount = 10;
	private List<SpawnPoint> activeSpawnPointList;

	// Use this for initialization
	void Start () {
		CheckActiveSpawnPointList ();
		for (int i = 0; i < MonsterCount; i++) {
			Spawn ();
		}
		InvokeRepeating ("checkActiveSpawnPointList",0.5f,0.5f);
	}

	public void CheckActiveSpawnPointList(){
		activeSpawnPointList = new List<SpawnPoint>();
		for (int i = 0; i < spawnPointList.Count; i++) {
			SpawnPoint spawnPoint = spawnPointList [i];
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
