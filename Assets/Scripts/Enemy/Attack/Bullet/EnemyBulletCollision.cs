using UnityEngine;
using System.Collections;

public class EnemyBulletCollision : MonoBehaviour 
{
	private float _damage;
	private FuelReservoir _characterFuelReservoir;

	void Awake()
	{
		_characterFuelReservoir= GameObject.FindGameObjectWithTag ("Character").GetComponent<FuelReservoir> ();
	}
		
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Character")
		{
			_characterFuelReservoir.UseFuel ((int)_damage);


			Destroy (gameObject);
		}
		if (other.gameObject.tag != "Enemy" && other.gameObject.tag!="Plane" &&other.gameObject.tag!="Blackhole") 
		{
			
			Destroy (gameObject);
		}
	}
	public void SetDamage(float amount)
	{
		_damage=amount;
	}
}
