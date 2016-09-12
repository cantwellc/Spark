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
		
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Character")
		{
			_characterHealth.TakeDamage (_damage);

			Destroy (gameObject);
		}
		if (other.tag != "Enemy") 
		{
			
			Destroy (gameObject);
		}
	}
	public void SetDamage(float amount)
	{
		_damage=amount;
	}
}
