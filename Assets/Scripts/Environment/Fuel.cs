using UnityEngine;
using System.Collections;

public class Fuel : MonoBehaviour 
{

	public int fuelAmmount;
	private Character _character;


	void Awake()
	{
		_character = GameObject.FindGameObjectWithTag ("Character").GetComponent<Character> ();

	}
		
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Character")
		{
			_character.AddFuel (fuelAmmount);
			Destroy (gameObject);
		}
	}
}
