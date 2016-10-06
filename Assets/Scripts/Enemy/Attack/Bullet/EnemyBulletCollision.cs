using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class EnemyBulletCollision : MonoBehaviour 
{
	protected float _damage = 10;
	private FuelReservoir _characterFuelReservoir;
	public UnityEvent onCharacterCollision;


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
			onCharacterCollision.Invoke ();
			Destroy (gameObject);
		}
		if (other.gameObject.tag != "Enemy" && other.gameObject.tag!="Plane" &&other.gameObject.tag!="Blackhole" && other.gameObject.tag!="ExtraCollider") 
		{
			
			Destroy (gameObject);
		}
	}
	virtual public void SetDamage(float amount)
	{
		_damage=amount;
	}
}
