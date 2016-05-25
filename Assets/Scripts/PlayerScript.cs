using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	/// <summary>
	/// Variable for the speed
	/// </summary>
	public Vector2 speed = new Vector2 (50, 50);

	/// <summary>
	/// Variable for the movement.
	/// </summary>
	private Vector2 movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Here we get the information about what the player done.
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		//We affect the movement in function of speed.
		movement = new Vector2 (speed.x * inputX, speed.y * inputY);
	}

	void FixedUpdate()
	{
		//Here we affect the movement to the object.
		GetComponent<Rigidbody2D>().velocity = movement;
	}
}
