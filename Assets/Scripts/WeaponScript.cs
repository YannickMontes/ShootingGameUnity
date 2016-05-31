using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour 
{
	/// <summary>
	/// The shot prefab.
	/// </summary>
	public Transform shotPrefab;
	/// <summary>
	/// The shooting rate.
	/// </summary>
	public float shootingRate = 0.25f;
	/// <summary>
	/// The shot cooldown.
	/// </summary>
	private float shotCooldown;

	// Use this for initialization
	void Start () 
	{
		//Put the shotCooldown to zero in order to be able to shot instantly.
		shotCooldown = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Every frame, we check if the shot is in cooldown. If it is, then we decrease the cooldown by the passed time.
		if (shotCooldown > 0) 
		{
			shotCooldown -= Time.deltaTime;
		}
	}

	/// <summary>
	/// Method called when the object want to shot.
	/// </summary>
	/// <param name="ennemy">Is it an ennemy?.</param>
	public void Attack(bool ennemy)
	{
		//Before everything, we check if the actual object can attack, meaning if the shot is not in cooldown.
		if (CanAttack) 
		{
			//When he attack, we put the shot in cooldown
			shotCooldown = shootingRate;
			//We instantiate a shot
			Transform shotTransform = Instantiate (shotPrefab) as Transform;
			//Put the shot right at the place where is the object
			shotTransform.position = transform.position;
			//Called the shot script
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript> ();
			if (shot != null) 
			{
				shot.isEnnemyShot = ennemy;
			}
			//Called the move script for the shot.
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript> ();
			if (move != null) 
			{
				move.direction = this.transform.right;//Right because 2D space.
			}
		}
	}

	/// <summary>
	/// Tell if the object can attack or not.
	/// </summary>
	/// <value><c>true</c> if this instance can attack; otherwise, <c>false</c>.</value>
	public bool CanAttack 
	{
		get 
		{
			return this.shotCooldown <= 0f;
		}
	}
}
