using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float MaxHealth;
	private float currentHealth;

	void Start()
	{
		currentHealth = MaxHealth;
	}
	public void TakeDamage(float ammount)
	{
		currentHealth -= ammount;
		if (currentHealth <= 0)
		{
			Dead ();
		}
	}
	void Dead()
	{
		//Remove the enemy from the scene
		Destroy (gameObject);
	}

}
