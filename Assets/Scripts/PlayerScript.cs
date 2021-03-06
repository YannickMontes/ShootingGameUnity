﻿using UnityEngine;
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

		//Here we get the action of shooting by pressing space button.
		bool shoot = Input.GetKeyDown (KeyCode.Space);
		//shoot |= Input.GetKeyDown (KeyCode.Space);
		//If the player press space.
		if (shoot) 
		{
			//We get the weapon
			WeaponScript weapon = GetComponent<WeaponScript> ();
			if (weapon != null) 
			{
				//False because player is not an ennemy.
				weapon.Attack (false);
			}
		}
	}

	void FixedUpdate()
	{
		//Here we affect the movement to the object.
		GetComponent<Rigidbody2D>().velocity = movement;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		bool damagePlayer = false;

		EnnemyScript ennemy = collision.gameObject.GetComponent<EnnemyScript> ();

		if (ennemy != null) 
		{
			Destroy (gameObject);	
		}
	}
}
