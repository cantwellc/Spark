using UnityEngine;
using System.Collections;

public class LeechDroneAttach : MonoBehaviour {

	private float _speed = 2;
	public Transform droneTransform;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter()
	{
		float cx = Character.current.transform.position.x;
		float cz = Character.current.transform.position.z;
		float r = 1.0f;
		float eulerAngleY = Character.current.transform.rotation.eulerAngles.y +180;
		float angleInDegrees =  (eulerAngleY > 180.0f) ? eulerAngleY - 360.0f : eulerAngleY;
		float a = angleInDegrees * Mathf.Deg2Rad;

		Vector3 attachTo = new Vector3(cx - r * Mathf.Cos (a),1.0f, cz + r * Mathf.Sin (a));
		droneTransform.position = Vector3.MoveTowards (droneTransform.position, attachTo, _speed * Time.deltaTime);
	
	}

	void OnTriggerStay()
	{
		if (Vector3.Distance (transform.position, Character.current.transform.position) > 0.2f)
		{
			float cx = Character.current.transform.position.x;
			float cz = Character.current.transform.position.z;
			float r = 1.0f;
			float eulerAngleY = Character.current.transform.rotation.eulerAngles.y + 180;
			float angleInDegrees = (eulerAngleY > 180.0f) ? eulerAngleY - 360.0f : eulerAngleY;
			float a = angleInDegrees * Mathf.Deg2Rad;

			Vector3 attachTo = new Vector3 (cx - r * Mathf.Cos (a), 1.0f, cz + r * Mathf.Sin (a));
			droneTransform.position = Vector3.MoveTowards (droneTransform.position, attachTo, _speed * Time.deltaTime);
		}
	}
}
