using UnityEngine;
using System.Collections;

public class FloorColoring : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name.Contains ("FloorTile"))
		{
			other.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			SuckFuelByDistance suckFuelOnDistance = other.gameObject.AddComponent<SuckFuelByDistance> () as SuckFuelByDistance;

		}
	}
}
