using UnityEngine;
using System.Collections;

public class RotateWithFuel : MonoBehaviour {
    public bool rotateClockwise;
    public bool rotateX;
    public bool rotateY;
    public bool rotateZ;
    public FuelReservoir fuelReservoir;
	
	// Update is called once per frame
	void Update () {
        var r = (1 -(fuelReservoir.fuelCount / fuelReservoir.maxFuelCount)) * 180;
        if (rotateClockwise) r = -r;
        var rX = rotateX ? r : 0.0f;
        var rY = rotateY ? r : 0.0f;
        var rZ = rotateZ ? r : 0.0f;
        transform.localEulerAngles = new Vector3(rX, rY, rZ);
	}
}
