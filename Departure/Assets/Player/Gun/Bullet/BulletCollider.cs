using UnityEngine;
using System.Collections;

public class BulletCollider : MonoBehaviour {
	
	public GameObject bullet;
	
	public int maxHeight = 100;
	public int minHeight = -50;
	
	void Update() 
	{
		// Bullet goes to high
		if (bullet.transform.position.y >= maxHeight)
		{
			Debug.Log("Bullet: Flew off into space");
			GameObject.Destroy(bullet);
		}
		
		// Bullet goes to low
		if (bullet.transform.position.y <= minHeight)
		{
			Debug.Log("Bullet: Fell to the depths");
			GameObject.Destroy(bullet);
		}
	}
	
	/*void OnTriggerEnter(Collider collision)
	{
		if (collision.CompareTag("Wall"))
		{
			Debug.Log("Bullet: Hit Wall");
			GameObject.Destroy(bullet);
		}

		if (collision.CompareTag("Floor"))
		{
			Debug.Log("Bullet: Hit Floor");
			GameObject.Destroy(bullet);
		}
	}*/
	void OnCollisionEnter(Collision collision) 
	{
		if (collision.gameObject.tag == "Enemy")
		{
			Debug.Log("Bullet: Hit Enemy");
			//targetPoints.points = targetPoints.points + 10;
			GameObject.Destroy(bullet);
		}

		if (collision.gameObject.tag == "Wall")
		{
			Debug.Log("Bullet: Hit Wall");
			GameObject.Destroy(bullet);
		}
		
		if (collision.gameObject.tag == "Floor")
		{
			Debug.Log("Bullet: Hit Floor");
			GameObject.Destroy(bullet);
		}
	}
}
