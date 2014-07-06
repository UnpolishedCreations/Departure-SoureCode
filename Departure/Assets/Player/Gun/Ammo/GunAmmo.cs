using UnityEngine;
using System.Collections;

public class GunAmmo : MonoBehaviour {
	
	static public int currAmmo = 8;
	static public int currTotalAmmo = 24;
	
	/*
	 * Display Ammo
	 */
	void OnGUI() 
	{
		GUI.Label(new Rect(40, 
		                   Screen.height - 30,
		                   100,
		                   50), 
		          currAmmo + " / " + currTotalAmmo);
		
		//GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom right");
	}
}
