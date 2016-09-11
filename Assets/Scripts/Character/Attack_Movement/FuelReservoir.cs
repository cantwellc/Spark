using UnityEngine;
using System.Collections;

public class FuelReservoir : MonoBehaviour {

    public int maxFuelCount = 5000;
    public int fuelCount = 5000;
    
    public enum FuelUseType
    {
        PlasmaBullet=0,
        BlackHole
    }

    //How much fuel to use when doing certain action.
    //0 for plasma bullet, 1 for black hole, like the enum above.
    public int[] fuelUseAmountForType;
    
	void Start () {
	
	}
	
    /// <summary>
    /// Add fuel by FuelAmount.
    /// </summary>
    /// <param name="fuelAmount"></param>
	public void AddFuel(int fuelAmount)
    {
        fuelCount += fuelAmount;
        if (fuelCount > maxFuelCount) fuelCount = maxFuelCount;
    }

    /// <summary>
    /// Takes in the fuel amount to use, returns true when fuel is enough, false if fuel is not enough
    /// For now, fuel can be used even if you only have 3 but you need 5.
    /// </summary>
    /// <param name="fuelAmount"></param>
    /// <returns></returns>
    public bool UseFuel(int fuelAmount)
    {
        if(fuelAmount > 0)
        {
            fuelCount -= fuelAmount;
            if (fuelCount < 0) fuelCount = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Returns true when fuel is enough, false if fuel is not enough
    /// For now, fuel can be used even if you only have 3 but you need 5.
    /// Use types to decrease the fuel count.
    /// </summary>
    /// <param name="fuelUseType"></param>
    /// <returns></returns>
    public bool UseFuel(FuelUseType fuelUseType)
    {
        switch(fuelUseType)
        {
            case FuelUseType.PlasmaBullet:
                if (fuelCount <= 0) return false;
                fuelCount -= fuelUseAmountForType[0];
                if (fuelCount < 0) fuelCount = 0;
                return true;
            case FuelUseType.BlackHole:
                if (fuelCount <= 0) return false;
                fuelCount -= fuelUseAmountForType[1];
                if (fuelCount < 0) fuelCount = 0;
                return true;
            default:
                return false;
        }
        
    }


}
