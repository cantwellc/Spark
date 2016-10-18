using UnityEngine;
using System.Collections;

public class SuckFuelByDistance : MonoBehaviour {

	// Use this for initialization
	private Transform _characterTransform;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Character.current != null)
		{
			if (Vector3.Distance (Character.current.transform.position, transform.position) <5.0f)
			{
				Character.current.GetComponent<CharacterHealth> ().TakeDamage (250.0f);
			}
		}
	}

}
