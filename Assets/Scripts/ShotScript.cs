using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	/// <summary>
	/// Inflected damages.
	/// </summary>
	public int damages = 1;

	/// <summary>
	/// Is it a shot from the player or not?
	/// </summary>
	public bool isEnnemyShot = false;

	// Use this for initialization
	void Start () 
	{
		//We limit the time to live of a shot to 20 seconds.
		Destroy (gameObject, 20);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
