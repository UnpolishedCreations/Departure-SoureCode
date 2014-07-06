using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {

	public bool hitplayer = false;
	public GameObject player;
	public static float moveSpeed = 0.02F;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player"); //Get the player/target
	}
	
	void Update()
	{
		//check to see if player is hit
		if (!hitplayer) 
		{
			//move towards player
			transform.position = Vector3.MoveTowards(transform.position,player.transform.position, moveSpeed); 
		}

		if (hitplayer)
		{
			Debug.Log("Player has died.");
			StartGame.gameStarted = false;
			// destroy all enemies
			GameObject [] enemies;
			enemies = GameObject.FindGameObjectsWithTag("Enemy");
			foreach (Object Enemy in enemies)
			{
				Destroy(Enemy);
			}
		}
	}
	
	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			Debug.Log("Enemy Hit Player.");
			hitplayer = true;
		}
	}

	
	void OnCollisionExit (Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			hitplayer = false;
		}
	}
}
