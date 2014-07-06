using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class EnemyKilled : MonoBehaviour {

	public float waitTime = 1.0F;
	public GameObject enemy;
	public GameObject enemyDied;
	public AudioClip enemyDiedSFX;

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Bullet")
		{
			PlayerScore.score = PlayerScore.score + 1;
			StartCoroutine("KillEnemy");
		}
	}


	IEnumerator KillEnemy ()
	{
		audio.PlayOneShot(enemyDiedSFX);
		Rigidbody enemyDiedX = Instantiate(enemyDied, this.transform.position, transform.rotation) as Rigidbody;

		StartCoroutine("DestroyEnemy");
		yield return new WaitForSeconds(waitTime);
		Destroy(enemyDiedX);
	}

	IEnumerator DestroyEnemy ()
	{
		yield return new WaitForSeconds(waitTime);
		Destroy(enemy);
	}

	void Update () 
	{
		// Increase difficulty at X amount of kills
		if (PlayerScore.increase1 && PlayerScore.score >= 5 && PlayerScore.score < 10) 
		{
			SpawnEnemies.spawnRate = SpawnEnemies.spawnRate - 0.5F;
			PlayerScore.increase1 = false;
		}

		if (PlayerScore.increase2 && PlayerScore.score >= 10 && PlayerScore.score < 20) 
		{
			SpawnEnemies.spawnRate = SpawnEnemies.spawnRate - 0.5F;
			MoveEnemy.moveSpeed = MoveEnemy.moveSpeed + 0.01F;
			PlayerScore.increase2 = false;
		}

		if (PlayerScore.increase3 && PlayerScore.score >= 20 && PlayerScore.score < 30) 
		{
			SpawnEnemies.spawnRate = SpawnEnemies.spawnRate - 0.5F;
			MoveEnemy.moveSpeed = MoveEnemy.moveSpeed + 0.01F;
			PlayerScore.increase3 = false;
		}

		if (PlayerScore.increase4 && PlayerScore.score >= 30 && PlayerScore.score < 45) 
		{
			SpawnEnemies.spawnRate = SpawnEnemies.spawnRate - 0.5F;
			MoveEnemy.moveSpeed = MoveEnemy.moveSpeed + 0.01F;
			PlayerScore.increase4 = false;
		}

		if (PlayerScore.increase5 && PlayerScore.score >= 45 && PlayerScore.score < 60) 
		{
			SpawnEnemies.spawnRate = SpawnEnemies.spawnRate - 0.5F;
			MoveEnemy.moveSpeed = MoveEnemy.moveSpeed + 0.01F;
			PlayerScore.increase5 = false;
		}

		if (PlayerScore.increase6 && PlayerScore.score >= 60 && PlayerScore.score < 80) 
		{
			SpawnEnemies.spawnRate = SpawnEnemies.spawnRate - 0.5F;
			PlayerScore.increase6 = false;
		}
	}
}
