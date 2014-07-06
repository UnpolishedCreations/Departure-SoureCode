using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class PlayerScore : MonoBehaviour {
	
	public AudioClip levelUpSFX;
	
	static public int score = 0;
	static public int highScore = 0;
	static public int currLevel = 1;
	
	static public bool increase1 = true;
	static public bool increase2 = true;
	static public bool increase3 = true;
	static public bool increase4 = true;
	static public bool increase5 = true;
	static public bool increase6 = true;
	
	static public bool addScore = false;
	
	public GameObject player;
	public Rigidbody levelUp;
	private Rigidbody levelUpCreate;
	
	// Use this for initialization
	void Start () {
		score = 0;
		audio.clip = levelUpSFX;

		increase1 = true;
		increase2 = true;
		increase3 = true;
		increase4 = true;
		increase5 = true;
		increase6 = true;
	}
	
	void Update()
	{
		if (score > highScore)
		{
			highScore = score;
		}
		
	/*	if (score >= 10 && score <= 20 && StartGame.gameStarted)
		{
			if (increase1) 
			{
				//obstacleCreator.projectileSpeed = obstacleCreator.projectileSpeed + 1;
				levelUpCreate = Instantiate(levelUp, player.transform.position, transform.rotation) as Rigidbody;
				Destroy(levelUpCreate);
				audio.Play();
				currLevel = currLevel + 1;
				increase1 = false;
			}
			
		}*/
	}

}
