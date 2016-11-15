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

	public void TakeDamageWithVFX(float amount,string VFX)
	{
		GetComponent<FuelReservoir>().UseFuel(amount);
		if (amount > 1 && onTakeDamageIntervalRemain <= 0)
		{
			onTakeDamageIntervalRemain = onTakeDamageInterval;
			onTakeDamage.Invoke ();
		}
		string vfxPrefabName = "CharacterHitEffects/"+VFX;
		GameObject vfxPrefab = (GameObject)Resources.Load (vfxPrefabName);
		GameObject vfxInstance = Instantiate (vfxPrefab, transform.position, transform.rotation) as GameObject;
		vfxInstance.transform.parent = gameObject.transform;
	}

	// Update is called once per frame
	void Update () {
        if(onTakeDamageIntervalRemain > 0)
            onTakeDamageIntervalRemain -= Time.deltaTime;
    }
}