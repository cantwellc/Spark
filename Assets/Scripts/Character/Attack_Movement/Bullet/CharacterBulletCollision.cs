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
			Destroy (gameObject);
		}
		if (other.tag != "Character" && other.tag != "Wall") 
		{
			Destroy (gameObject);
		}
	}
	public void SetDamage(float amount)
	{
		_damage = amount;
	}
}
