using UnityEngine;
using System.Collections;

public class SpawnPointController : MonoBehaviour {
	public bool isActive = true;
	public float spawnDelay = 0.3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn(GameObject spawnObject){
		Transform monsterPosition = gameObject.transform;
		Instantiate (spawnObject, monsterPosition.position, monsterPosition.rotation);
		isActive = false;
		Invoke ("reset", spawnDelay);
	}

	private void reset(){
		isActive = true;
	}
}
