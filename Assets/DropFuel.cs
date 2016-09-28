using UnityEngine;
using System.Collections;

public class DropFuel : MonoBehaviour {

	public Transform bossTransform;
	public GameObject fuel;
	private GameObject _fuelInstance;
	public void DropFuelCircular()
	{
		
		if (Random.Range (0.0f, 50.0f) <= 8.0f)
		{
			float r = Random.Range (7f, 10.0f);
			float cx = bossTransform.transform.position.x;
			float cz = bossTransform.transform.position.z;
			float angle = Random.Range (0.0f, 360.0f);
			float angleRad = angle * Mathf.Deg2Rad;
			float x = cx + r * Mathf.Cos (angleRad);
			float z = cz + r * Mathf.Sin (angleRad);
			Vector3 fuelPosition = new Vector3 (x, 1.0f, z);
			_fuelInstance = Instantiate (fuel, fuelPosition, transform.rotation) as GameObject;
			_fuelInstance.GetComponent<Fuel> ().fuelAmmount = Random.Range (250, 350);
			_fuelInstance.GetComponent<Fuel> ().ScaleFuel ();
		}


	}
}
