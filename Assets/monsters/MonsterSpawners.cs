using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterSpawners : MonoBehaviour {
	public GameObject[] monsterPrefabs;
	public Transform[] spawnLocations;

	static GameObject liveMonsters;
	// Use this for initialization
	void Start () {
		liveMonsters = new GameObject ("Live Monsters");
		liveMonsters.transform.parent = transform;

		InvokeRepeating ("Spawn", 3, 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn() {
		GameObject prefab = monsterPrefabs [Random.Range (0, monsterPrefabs.Length)];
		Transform location = spawnLocations [Random.Range (0, spawnLocations.Length)];
		GameObject monster = Instantiate (prefab, location.position, location.rotation, liveMonsters.transform);
		NavMeshAgent agent = monster.GetComponentInChildren<NavMeshAgent> ();
		// set agent destination
		agent.avoidancePriority = Random.Range(0, 100);
	}

	public static Transform GetLiveMonsters() {
		return liveMonsters.transform;
	}
}
