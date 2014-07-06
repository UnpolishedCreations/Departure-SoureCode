using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class PickupClip : MonoBehaviour {
	
	public int basicClipRespawnTime = 60;
	public AudioClip pickupClip_SFX;
	
	void OnTriggerEnter(Collider pickup)
	{
		if(pickup.CompareTag("Clip"))
		{
			// Can't have more than 24 total bullets, or 3 clips at one time
			if (GunAmmo.currTotalAmmo <= 16)
			{
				Debug.Log("Pick up clip");
				audio.PlayOneShot(pickupClip_SFX);
				GunAmmo.currTotalAmmo = GunAmmo.currTotalAmmo + 8;
				
				pickup.renderer.enabled = false;
				pickup.collider.enabled = false;
				
				StartCoroutine(respawnClip(pickup));
			}
		}
	}
	
	IEnumerator respawnClip(Collider pickup) 
	{
		yield return new WaitForSeconds(basicClipRespawnTime);
		pickup.renderer.enabled = true;
		pickup.collider.enabled = true;
	}
}
