using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TriggerCrush : MonoBehaviour {

	public GameObject wall;

	// Use this for initialization
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Character")
		{
			wall.GetComponent<Crush> ().StartCrushing();


		}
	}
}
