using UnityEngine;
using System.Collections;

public class CharacterHealth : Health {

	public override void TakeDamage(float amount)
    {
        GetComponent<FuelReservoir>().UseFuel(amount);

        OnTakeDamage.Invoke();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
