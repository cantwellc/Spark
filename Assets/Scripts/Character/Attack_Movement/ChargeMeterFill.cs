using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChargeMeterFill : MonoBehaviour {

    public Image fillImage;
    public float minChargingFill;
    public float maxChargingFill;
    public FireBehavior fireBehavior;
    public FuelReservoir fuelReservoir;

    public bool _charging;

	void Awake()
	{
		fillImage.fillAmount = 0.0f;
	}

    void Start()
    {
        if (fireBehavior == null || fuelReservoir == null) return;
        minChargingFill = fireBehavior.minChargeFuelCost / fuelReservoir.maxFuelCount;
        maxChargingFill = fireBehavior.maxChargeFuelCost / fuelReservoir.maxFuelCount;
    }

    public void Charging()
    {
        _charging = true;
    }
    public void ChargeComplete()
    {
        _charging = false;
    }
    public void ChargeDepleted()
    {
        _charging = false;
        fillImage.fillAmount = 0.0f;
    }

    void Update()
    {
        if (!_charging) return;
        fillImage.fillAmount = (maxChargingFill - minChargingFill)*fireBehavior.ChargeRatio;
    }
}
