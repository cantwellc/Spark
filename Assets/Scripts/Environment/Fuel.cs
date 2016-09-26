using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Fuel : MonoBehaviour 
{
	public int fuelAmmount;
	public UnityEvent onGatherSfx;
	private float sizeCoefficient=1.2f;
	private Character _character;


	void Awake()
	{
		_character = GameObject.FindGameObjectWithTag ("Character").GetComponent<Character> ();
		float sizeScale =  sizeCoefficient *(float)fuelAmmount / _character.GetComponent<FuelReservoir> ().maxFuelCount;
		transform.localScale = new Vector3 (sizeScale, sizeScale, sizeScale);

	}
		
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Character")
		{
			
			onGatherSfx.Invoke ();
			_character.AddFuel (fuelAmmount);
			Destroy (gameObject);
		}
	}
}
