using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{


	public float maxHealth;
	public bool removeFromSceneWhenDead;

	private float _currentHealth;

	void Start () 
	{
		_currentHealth = maxHealth;
	}

	//Reduce the Ammount from health of the gameobject
	public void TakeDamage(float amount)
	{
		_currentHealth -= amount;
		if (_currentHealth <= 0)
		{
			Dead ();
		}
	}

	void Dead()
	{
		if (removeFromSceneWhenDead)
		{
			Destroy (gameObject);
		}
	}



}
