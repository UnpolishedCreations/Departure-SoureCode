using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public GameObject playCam;
	public GameObject controlCam;

	// Use this for initialization
	void Start () 
	{
		this.transform.position = controlCam.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(StartGame.gameStarted)
		{
			this.transform.position = playCam.transform.position;
		}
		else
		{
			this.transform.position = controlCam.transform.position;
		}
	}
}
