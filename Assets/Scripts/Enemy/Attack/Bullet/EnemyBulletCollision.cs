using UnityEngine;
using System.Collections;

public class EnemyBulletCollision : MonoBehaviour 
{
	private float _damage;
	private Health _characterHealth;

	void Awake()
	{
		_characterHealth= GameObject.FindGameObjectWithTag ("Character").GetComponent<Health> ();
	}
		
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Character")
		{
			_characterHealth.TakeDamage (_damage);

			Destroy (gameObject);
		}
		if (other.gameObject.tag != "Enemy") 
		{
			
			Destroy (gameObject);
		}
	}
	public void SetDamage(float amount)
	{
		_damage=amount;
	}
}
