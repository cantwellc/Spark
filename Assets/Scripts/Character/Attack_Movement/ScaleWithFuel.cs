using UnityEngine;
using System.Collections;

public class ScaleWithFuel : MonoBehaviour {
    
    public FuelReservoir _fuelReservoir;

    private float _ratio;
    private Transform _fuelTransform;

    void Awake()
    {
        _fuelTransform = GetComponent<Transform>();
    }

    void Start()
    {
        _ratio = (float)_fuelReservoir.fuelCount / _fuelReservoir.maxFuelCount;
        _fuelTransform.localScale = new Vector3(_ratio, _ratio, _ratio);

    }

	// Update is called once per frame
	void Update () {
        _ratio = (float)_fuelReservoir.fuelCount / _fuelReservoir.maxFuelCount;
        _fuelTransform.localScale = new Vector3(_ratio, _ratio, _ratio);
    }

}
