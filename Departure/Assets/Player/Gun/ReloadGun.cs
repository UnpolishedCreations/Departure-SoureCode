using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class ReloadGun : MonoBehaviour {
	
	/* 
	 * Used for reloading mechanics 
	 */
	public bool seq1 = false;
	public bool seq2 = false;
	public bool seq3 = false;
	public bool reloadComplete = false;
	public bool reload = false;
	
	
	public AudioClip reload_SFX;
	
	//public int gunClipSize = 8;
	
	// Lerp Reload Gun Objects Variables
	/*public GameObject L;
	public GameObject ML;
	public GameObject MR;
	public GameObject R;
	public float delayTime;
	public Vector3 posA;
	public Vector3 posB;*/
	
	// Update is called once per frame
	void Update () 
	{
		if (GunAmmo.currTotalAmmo > 0) 
		{
			initReloadSequence();
		}
	}
	
	/*
	 * Initilize reloading sequence
	 */
	void initReloadSequence() 
	{
		// Reload Sequence
		if (Input.GetKey("1")) 
		{
			seq1 = true;

			// drop clip on ground, penalty for trying to init reload squence early.
			GunAmmo.currAmmo = 0; 
		}
		else if (Input.GetKey("3") && seq1) 
		{
			seq2 = true;
		}
		else if (Input.GetKey("2") && seq2) 
		{
			seq3 = true;
		}
		else if (Input.GetKey("4") && seq3) 
		{
			reloadComplete = true;
			audio.PlayOneShot(reload_SFX);
		}
		
		// If Reload Sequence Complete, Reload Gun
		if(reloadComplete) 
		{
			if(GunAmmo.currTotalAmmo >=8) 
			{
				GunAmmo.currAmmo = 8;
				GunAmmo.currTotalAmmo =  GunAmmo.currTotalAmmo - 8;
			}
			else
			{
				GunAmmo.currAmmo = GunAmmo.currTotalAmmo;
				GunAmmo.currTotalAmmo = 0;
			}
			
			ShootProjectile.canFire = true;
			seq1 = false;
			seq2 = false;
			seq3 = false;
			reloadComplete = false;
		}
	}
	
	
	/*	IEnumerator x()
	{
		yield return new WaitForSeconds(delayTime); // start at time X
		float startTime = Time.time; // Time.time contains current frame time, so remember starting point

		while (Time.time-startTime <= 1)
		{ 
			// until one second passed
			L.transform.position = Vector3.Lerp(posA, new Vector3(2, 2, 1), Time.time-startTime); // lerp from A to B in one second
			yield return 1; // wait for next frame
		}
	} */
	
	/*
	 * Display current ammo / total ammo the player has
	 */
	void OnGUI() {
		// Display player has no ammo
		if(GunAmmo.currTotalAmmo == 0 && GunAmmo.currAmmo == 0)
		{
			GUI.contentColor = Color.red;
			GUI.Label(new Rect(	Screen.width - (Screen.width/4), 
			                   Screen.height - 30,
			                   100,
			                   50), 
			          "EMPTY ");
		}
		// Display Reload warning
		else
		{
			GUI.contentColor = Color.red;
			if (GunAmmo.currAmmo == 0) 
			{
				GUI.Label(new Rect(	Screen.width - (Screen.width/4), 
				                   Screen.height - 30,
				                   100,
				                   50), 
				          "RELOAD: ");
			}
			
			// Show Reload Sequence Needed to Reload
			GUI.contentColor = Color.white;
			if (!seq1 && GunAmmo.currAmmo == 0) 
			{
				GUI.Label(new Rect(	Screen.width - (Screen.width/4) + 60, 
				                   Screen.height - 30,
				                   100,
				                   50), 
				          "1");
			}
			if (!seq2 && GunAmmo.currAmmo == 0) 
			{
				GUI.Label(new Rect(	Screen.width - (Screen.width/4) + 75, 
				                   Screen.height - 30,
				                   100,
				                   50), 
				          "3");
			}
			if (!seq3 && GunAmmo.currAmmo == 0) 
			{
				GUI.Label(new Rect(	Screen.width - (Screen.width/4) + 90, 
				                   Screen.height - 30,
				                   100,
				                   50), 
				          "2");
			}
			if (!reloadComplete && GunAmmo.currAmmo == 0) 
			{
				GUI.Label(new Rect(	Screen.width - (Screen.width/4) + 105, 
				                   Screen.height - 30,
				                   100,
				                   50), 
				          "4");
			}
			//GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom right");
		}
	}
}
