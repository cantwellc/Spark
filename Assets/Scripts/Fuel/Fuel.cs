using UnityEngine;
using System.Collections;

public class Fuel : MonoBehaviour {


	private Ship Ship;
	public int FuelAmmount;

	void Awake()
	{
		Ship = GameObject.FindGameObjectWithTag ("Player").GetComponent<Ship> ();

	}



	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Ship.GetAmmo (FuelAmmount);
			Destroy (gameObject);
		}
	}
}
