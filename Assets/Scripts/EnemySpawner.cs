using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	[SerializeField]
	GameObject player;
	[SerializeField]
	GameObject SpawnerPoint;
	[SerializeField]
	GameObject enemy;
    [SerializeField]
	float spawnTime;

	void Start () {
        InvokeRepeating( "SpawnEnemy", Random.Range(1,spawnTime), Random.Range(1, spawnTime));
	}
	
	void SpawnEnemy () {
		GameObject go = Instantiate(enemy, SpawnerPoint.transform.position, Quaternion.identity) as GameObject;
		go.transform.position = SpawnerPoint.transform.position;
		go.GetComponent<Enemy>().GetTarget(player.transform);
	}
}
