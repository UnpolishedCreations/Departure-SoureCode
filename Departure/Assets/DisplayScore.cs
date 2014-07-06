using UnityEngine;
using System.Collections;

public class DisplayScore : MonoBehaviour {

	
	void OnGUI() 
	{
		// Displays Score
		GUI.Label(new Rect(	40, 
		                   	Screen.height - 50,
		                   	100,
		                   	50), 
		         			"Score: " + PlayerScore.score);
		//Displays Highscore
		GUI.Label(new Rect(	40, 
		                   	Screen.height - 70,
		                   	100,
		                   	50), 
		          			"High Score: " + PlayerScore.highScore);
		
		//GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom right");
	}
}
