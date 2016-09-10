using UnityEngine;
using System.Collections;

public class CharacterBulletCollision : MonoBehaviour 
{

	private float _damage;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			Health enemyHealth = other.GetComponent<Health> ();
			enemyHealth.TakeDamage (_damage);

		}
	}
	public void SetDamage(float amount)
	{
		_damage = amount;
	}
}
