using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class SpawnEnemies : MonoBehaviour {
	
	/*
	 * Used to fire a projectile from the barrel of the gun
	 */
	static public bool canSpawn = true;
	public int spawnLocation;
	public GameObject[] enemySpawnPoint = new GameObject[4];
	public Rigidbody enemyPrefab;

	public static float spawnRate = 3.0F;
	//public AudioClip spawnSFX;

	void Update () 
	{
		// 	Spawn Enemy if canSpawn=true
		if (canSpawn && StartGame.gameStarted) 
		{
			initEnemy();
			//audio.PlayOneShot(spawnSFX);
			StartCoroutine(delayEnemySpawn());
		
		}

		/*
		if (player is dead)
		{
			canSpawn = false;
		}
		*/
	}
	
	/*
	 * Creates enemy
	 */
	void initEnemy() 
	{
		spawnLocation = Random.Range(0, 4);
		Rigidbody enemy = Instantiate(enemyPrefab, enemySpawnPoint[spawnLocation].transform.position, transform.rotation) as Rigidbody;
	}
	
	/*
	 * Controls spawn rate
	 */
	IEnumerator delayEnemySpawn() 
	{
		canSpawn = false;
		yield return new WaitForSeconds(spawnRate);
		canSpawn = true;
	}
}



