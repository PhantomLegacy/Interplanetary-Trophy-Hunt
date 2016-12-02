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
	float spawnTime = 2f;

	void Start () {
        InvokeRepeating( "SpawnEnemy", Random.Range( 1, 30 ), Random.Range( 1, 30 ) );
	}
	
	void SpawnEnemy () {
		GameObject go = Instantiate(enemy, SpawnerPoint.transform.position, Quaternion.identity) as GameObject;
		go.transform.position = SpawnerPoint.transform.position;
		go.GetComponent<Enemy>().Damage(0, player.transform);
	}
}
