using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivateMultiple : MonoBehaviour {
	
	public List<GameObject> objectsToActivate;
	// Use this for initialization

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Character")
		{
			foreach (GameObject gameObject in objectsToActivate)
			{
				gameObject.SetActive (true);
			}
		}

	}
}
