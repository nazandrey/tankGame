using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	public bool isActive = true;
	public float spawnDelay = 0.3f;

	public void Spawn(GameObject spawnObject){
		Transform monsterPosition = gameObject.transform;
		Instantiate (spawnObject, monsterPosition.position, monsterPosition.rotation);
		isActive = false;
		Invoke ("_Activate", spawnDelay);
	}

	private void _Activate(){
		isActive = true;
	}
}
