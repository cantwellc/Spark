using UnityEngine;
using System.Collections;

public class ShipBulletCollision : MonoBehaviour {

	private float Damage;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			EnemyHealth enemyHealth = other.GetComponent<EnemyHealth> ();
			enemyHealth.TakeDamage (Damage);

		}
	}
	public void SetDamage(float amount)
	{
		Damage = amount;
	}
}
