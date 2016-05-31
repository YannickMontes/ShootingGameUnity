using UnityEngine;
using System.Collections;

public class EnnemyScript : MonoBehaviour {

	private WeaponScript weapon;

	void Awake()
	{
		weapon = GetComponentInChildren<WeaponScript> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (weapon != null && weapon.CanAttack ) 
		{
			weapon.Attack (true);
		}
	}
}
