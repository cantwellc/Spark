using UnityEngine;
using System.Collections;

public class EnemyBulletCollision : MonoBehaviour 
{
	private float _damage = 10;
	private FuelReservoir _characterFuelReservoir;

	void Awake()
	{
        if (Character.current == null) return;
		_characterFuelReservoir= Character.current.GetComponent<FuelReservoir> ();
	}
		
	void OnTriggerEnter(Collider other)
	{
        if (!other || _characterFuelReservoir == null) return;
		if (other.gameObject.tag == "Character")
		{
            other.GetComponent<Health>().TakeDamage(_damage);


			Destroy (gameObject);
		}
		if (other.gameObject.tag != "Enemy" && other.gameObject.tag!="Plane" &&other.gameObject.tag!="Blackhole" && other.gameObject.tag!="ExtraCollider") 
		{
			
			Destroy (gameObject);
		}
	}
	public void SetDamage(float amount)
	{
		_damage=amount;
	}
}
