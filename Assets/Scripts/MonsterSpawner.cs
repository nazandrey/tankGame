using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterSpawner : MonoBehaviour {
	public List<SpawnPoint> spawnPointList;
	public GameObject[] monsterTypeArr;

	private const int _MonsterCount = 10;
	private List<SpawnPoint> _activeSpawnPointList;

	void Start () {
		CheckActiveSpawnPointList ();
		for (int i = 0; i < _MonsterCount; i++) {
			Spawn ();
		}
		InvokeRepeating ("checkActiveSpawnPointList",0.5f,0.5f);
	}

	public void CheckActiveSpawnPointList(){
		_activeSpawnPointList = new List<SpawnPoint>();
		for (int i = 0; i < spawnPointList.Count; i++) {
			SpawnPoint spawnPoint = spawnPointList [i];
			if (spawnPoint.isActive) {
				_activeSpawnPointList.Add(spawnPoint);
			}
		}
	}

	public void Spawn(){		
		int spawnPointIndex = Random.Range (0, _activeSpawnPointList.Count);
		int monsterTypeIndex = Random.Range (0, monsterTypeArr.Length);
		_activeSpawnPointList[spawnPointIndex].Spawn(monsterTypeArr [monsterTypeIndex]);
		_activeSpawnPointList.RemoveAt (spawnPointIndex);
	}
}
