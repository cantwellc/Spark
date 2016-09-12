using UnityEngine;
using System.Collections;

public class CharacterBulletCollision : MonoBehaviour 
{

	private float _damage;

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Health enemyHealth = other.gameObject.GetComponent<Health> ();
			enemyHealth.TakeDamage (_damage);
			Destroy (gameObject);
		}
		if (other.gameObject.tag != "Character" && other.gameObject.tag != "Wall") 
		{
			Destroy (gameObject);
		}
	}
	public void SetDamage(float amount)
	{
		_damage = amount;
	}
}
