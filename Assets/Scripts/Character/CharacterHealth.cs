using UnityEngine;
using System.Collections;

public class CharacterHealth : Health {

    float onTakeDamageInterval = 0.3f;
    float onTakeDamageIntervalRemain = 0;

    public new float MaxHealth
    {
        get
        {
            return GetComponent<FuelReservoir>().maxFuelCount;
        }
    }

    public override void TakeDamage(float amount)
	{
		GetComponent<FuelReservoir>().UseFuel(amount);
		if (amount > 1 && onTakeDamageIntervalRemain <= 0)
		{
            onTakeDamageIntervalRemain = onTakeDamageInterval;
            onTakeDamage.Invoke ();
		}
	}

	// Update is called once per frame
	void Update () {
        if(onTakeDamageIntervalRemain > 0)
            onTakeDamageIntervalRemain -= Time.deltaTime;
    }
}