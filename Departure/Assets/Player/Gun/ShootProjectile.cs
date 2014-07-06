using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class ShootProjectile : MonoBehaviour {
	
	/*
	 * Used to fire a projectile from the barrel of the gun
	 */
	static public bool canFire = true;
	
	public GameObject spawnProjectile;
	public Rigidbody projectilePrefab;
	public int projectileSpeed = 50;
	public float fireRate = 0.25F;
	public AudioClip shootSFX;
	
	/*  
	 *	Update is called once per frame
	 */
	void Update () 
	{
		// 	Fire gun
		if (Input.GetButtonDown("Fire1") && canFire && StartGame.gameStarted) 
		{
			initBullet();
			audio.PlayOneShot(shootSFX);
			StartCoroutine(delayGunFire());
			GunAmmo.currAmmo--;
		}
		
		if (GunAmmo.currAmmo <= 0)
		{
			canFire = false;
			GunAmmo.currAmmo = 0;
		}
	}
	
	/*
	 * Creates projectile w/velocity
	 */
	void initBullet() 
	{
		Rigidbody bullet = Instantiate(projectilePrefab, spawnProjectile.transform.position, transform.rotation) as Rigidbody;
		bullet.velocity = transform.TransformDirection(Vector3.forward * projectileSpeed);
	}
	
	/*
	 * Controls rate of fire
	 */
	IEnumerator delayGunFire() 
	{
		canFire = false;
		yield return new WaitForSeconds(fireRate);
		canFire = true;
	}
}



