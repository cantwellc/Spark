using UnityEngine;
using System.Collections;

public class ScaleWithFuel : MonoBehaviour {

    public FuelReservoir fuelReservoir;
    private Transform _transform;

    void Awake()
    {
        _transform = gameObject.transform;
    }

	// Update is called once per frame
	void Update () {
        float ratio = (float) fuelReservoir.fuelCount / fuelReservoir.maxFuelCount;
        _transform.localScale = new Vector3(ratio, ratio, ratio);
	}
}
