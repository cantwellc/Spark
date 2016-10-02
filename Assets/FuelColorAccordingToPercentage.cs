using UnityEngine;
using System.Collections;

public class FuelColorAccordingToPercentage : MonoBehaviour {

    public FuelReservoir fuelRes;

    private float _maxFuel;
    private float _curFuel;
    // Use this for initialization
	void Start () {
        _maxFuel = fuelRes.maxFuelCount;
        
	}
	
	// Update is called once per frame
	void Update () {
        ParticleSystem fuelPS = this.GetComponent<ParticleSystem>();
        _curFuel = fuelRes.fuelCount;
        if((_curFuel/_maxFuel)>= 0.5)
        {
            //Green Shader since we are above %50 fuel
            Debug.Log("Green");
            fuelPS.startColor = Color.green;
        }
        else if ((_curFuel/_maxFuel) > 0.2 && (_curFuel /_maxFuel) < 0.5)
        {
            //Yellow Shader since we are above %20 fuel and less than %50 fuel
            Debug.Log("Yellow");
            fuelPS.startColor = Color.yellow;
        }
        else if((_curFuel/_maxFuel) <= 0.2)
        {
            //Red Shader since we are under %20 fuel
            Debug.Log("Red");
            fuelPS.startColor = Color.red;
        }
	}
}
