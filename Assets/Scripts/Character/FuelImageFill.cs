using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FuelImageFill : MonoBehaviour {
    public Image fuelImage1;
    public Image fuelImage2;
    public FuelReservoir fuelReservoir;
	
	// Update is called once per frame
	void Update () {
        var ratio = fuelReservoir.fuelCount / (2 * fuelReservoir.maxFuelCount);
        fuelImage1.fillAmount = ratio;
        fuelImage2.fillAmount = ratio;
    }
}
