using UnityEngine;
using System.Collections;

public class FishSpawner : MonoBehaviour {

	public GameObject fish;
	public GameObject player;

	float spawnRate = 2;
	float nextSpawn;

	float spawnUpdateRate = 10;
	float nextSpawnUpdate;

	float spawnNumber = 1;

	float distFromPlayer = 15;
	float spawnRadius = 1.3f;

	void Start () {
		nextSpawnUpdate = Time.time + spawnUpdateRate;
		nextSpawn = Time.time + spawnRate;
	}
	
	void Update () {
		if (nextSpawn <= Time.time){
			spawnEnemy();
		}
		if (nextSpawnUpdate <= Time.time){
			spawnNumber += 1;
			nextSpawnUpdate = Time.time + spawnUpdateRate;
		}
	}

	void spawnEnemy(){
		Vector2 pos = NewSpawn();
		for (int i = 0; i < spawnNumber; i++){
			pos.x += Random.Range(-spawnRadius,spawnRadius);
			pos.y += Random.Range(-spawnRadius,spawnRadius);
			GameObject obj = Instantiate (fish, pos, Quaternion.identity) as GameObject;
		}
		nextSpawn = Time.time + spawnRate;
	}

	Vector2 NewSpawn(){
		Vector2 spawnLocation;
		spawnLocation.x = Random.Range(-20,20);
		spawnLocation.y = Random.Range(-10,10);
		if(Vector2.Distance(player.transform.position, spawnLocation) < distFromPlayer && Vector2.Distance(player.transform.position, spawnLocation) > -distFromPlayer){
			spawnLocation = NewSpawn();
		}
		return spawnLocation;
	}
}
