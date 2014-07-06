using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	
	static public bool gameStarted = false;
	
	// Use this for initialization
	void Start () 
	{
		gameStarted = false;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if (Input.GetButtonDown("Jump") && !gameStarted)
		{
			PlayerScore.score = 0;
			MoveEnemy.moveSpeed = 0.02F;
			SpawnEnemies.spawnRate = 3.0F;
			ShootProjectile.canFire = true;
			GunAmmo.currAmmo = 8;
			GunAmmo.currTotalAmmo = 24;

			gameStarted = true;
		}
	}
		
	
}
