using UnityEngine;
using System.Collections;

public class ShipHealth : MonoBehaviour {


	public float MaxHealth;

	private float currentHealth;
	void Start () 
	{
		currentHealth = MaxHealth;
	}

	//This will be called by enemies, obstacles,projectiles etc.
	public void TakeDamage(float amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			Dead ();
		}
	}

	void Dead()
	{
		Debug.Log ("Player is Dead");
	}



}
