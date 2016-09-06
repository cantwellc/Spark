using UnityEngine;
using System.Collections;

public class EnemyBulletCollision : MonoBehaviour {


	private float damage;
	//private ShipHealth shipHealth;


	void Start()
	{
		//shipHealth= GameObject.FindGameObjectWithTag ("Player").GetComponent<ShipHealth> ();
	}
		
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			//shipHealth.TakeDamage (damage);
			//Destroy (gameObject);
		}
	}
	public void SetDamage(float amount)
	{
		damage=amount;
	}
}
