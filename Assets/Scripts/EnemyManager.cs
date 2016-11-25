using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {
	public List<SpawnPointController> spawnPointList;
	public GameObject[] monsterTypeArr;
	private const int MonsterCount = 10;


	// Use this for initialization
	void Start () {
		List<SpawnPointController> activeSpawnPointList = new List<SpawnPointController>();
		for (int i = 0; i < spawnPointList.Count; i++) {
			SpawnPointController spawnPoint = spawnPointList [i];
			if (spawnPoint.isActive) {
				activeSpawnPointList.Add(spawnPoint);
			}
		}
		for (int i = 0; i < MonsterCount; i++) {
			int spawnPointIndex = Random.Range (0, activeSpawnPointList.Count);
			int monsterTypeIndex = Random.Range (0, monsterTypeArr.Length);
			activeSpawnPointList[spawnPointIndex].Spawn(monsterTypeArr [monsterTypeIndex]);
			activeSpawnPointList.RemoveAt (spawnPointIndex);			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
