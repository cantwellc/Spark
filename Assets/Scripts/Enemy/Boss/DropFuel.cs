using UnityEngine;
using System.Collections;

public class DropFuel : MonoBehaviour {

	private GameObject _fuelInstance;
	private float _percentageToDropHealth;

	public Transform bossTransform;
	public GameObject fuel;

	public Health bossHealth;
	public float percentageIntervalToDropFuel;

	void Start()
	{
		_percentageToDropHealth = bossHealth.HealthPercent *100 - percentageIntervalToDropFuel;
	}


	void Update()
	{
		
		while (bossHealth.HealthPercent *100  <= _percentageToDropHealth)
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
			_percentageToDropHealth -= percentageIntervalToDropFuel;
		}
	}

}
