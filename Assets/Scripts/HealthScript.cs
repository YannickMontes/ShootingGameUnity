using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	/// <summary>
	/// Total health points.
	/// </summary>
	public int hp = 1;

	/// <summary>
	/// Is this an ennemy?
	/// </summary>
	public bool isEnnemy = true;

	/// <summary>
	/// Function used to inflict damages to an entity.
	/// </summary>
	/// <param name="damageCount">Damage count.</param>
	public void Damage(int damageCount)
	{
		this.hp -= damageCount;

		if (hp <= 0) 
		{
			Destroy (gameObject);		
		}
	}

	/// <summary>
	/// Function called when the actual object hit an other object.
	/// </summary>
	/// <param name="otherCollider">Other object collider.</param>
	public void OnTriggerEnter2D(Collider2D otherCollider)
	{
		//Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript> ();
		if (shot != null) 
		{
			//Is this an Ennemy Shot?
			if (shot.isEnnemyShot != this.isEnnemy) 
			{
				Damage (shot.damages);//Inflict the damages

				Destroy (shot.gameObject);//Destroy the shot, because he hit the actual object.
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
