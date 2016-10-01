using UnityEngine;
using System.Collections;

public class StopFollow : MonoBehaviour {

	public Health droneHealth;

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Character")
		{
			droneHealth.TakeDamage (500);
		}
	}

}
