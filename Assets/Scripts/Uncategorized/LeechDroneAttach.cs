using UnityEngine;
using System.Collections;

public class LeechDroneAttach : MonoBehaviour {

	public float Speed = 2;
	public Transform droneTransform;
	private float _angleOfAttach; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Character")
		{
			float cx = Character.current.transform.position.x;
			float cz = Character.current.transform.position.z;
			float r = 1.0f;
			_angleOfAttach = Character.current.transform.rotation.eulerAngles.y + 90 + Random.Range (20, 190);
			//Debug.Log (_angleOfAttach);
			float angleInDegrees = (_angleOfAttach > 180.0f) ? _angleOfAttach - 360.0f : _angleOfAttach;
			float a = angleInDegrees * Mathf.Deg2Rad;

			Vector3 attachTo = new Vector3 (cx - r * Mathf.Cos (a), 1.0f, cz + r * Mathf.Sin (a));
			droneTransform.position = Vector3.MoveTowards (droneTransform.position, attachTo, Speed * Time.deltaTime);
		}
	
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Character")
		{
			if (Vector3.Distance (transform.position, Character.current.transform.position) > 0.2f)
			{
				float cx = Character.current.transform.position.x;
				float cz = Character.current.transform.position.z;
				float r = 1.0f;

				float angleInDegrees = (_angleOfAttach > 180.0f) ? _angleOfAttach - 360.0f : _angleOfAttach;
				float a = angleInDegrees * Mathf.Deg2Rad;

				Vector3 attachTo = new Vector3 (cx - r * Mathf.Cos (a), 1.0f, cz + r * Mathf.Sin (a));
				droneTransform.position = Vector3.MoveTowards (droneTransform.position, attachTo, Speed * Time.deltaTime);
			}
		}
	}
}
