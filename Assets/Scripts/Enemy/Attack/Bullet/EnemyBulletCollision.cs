using UnityEngine;
using System.Collections;

public class EnemyBulletCollision : MonoBehaviour 
{
	private float _damage;
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
			_characterFuelReservoir.UseFuel ((int)_damage);


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
