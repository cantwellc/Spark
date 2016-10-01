using UnityEngine;
using System.Collections;

public class DroneFollow : MonoBehaviour {

	private float _speed = 8;
	public Transform droneTransform;
	// Use this for initialization
	void Start () 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Character")
		{

			float distance = Vector3.Distance (droneTransform.position, Character.current.transform.position);
			if (distance > 4.0f)
			{
				droneTransform.position = Vector3.MoveTowards (droneTransform.position, Character.current.transform.position, _speed * Time.deltaTime);
			}
		}
	}
	void OnTriggerStay(Collider other)
	{

		if (other.gameObject.tag == "Character")
		{
			float distance = Vector3.Distance (droneTransform.position, Character.current.transform.position);
			if (distance > 4.0f)
			{
				droneTransform.position = Vector3.MoveTowards (droneTransform.position, Character.current.transform.position, _speed * Time.deltaTime);
			}
		}
	}
}
