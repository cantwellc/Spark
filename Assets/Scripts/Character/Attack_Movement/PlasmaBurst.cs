using UnityEngine;
using System.Collections;
using System;

public class PlasmaBurst : FireBehavior
{
    public Character character;
    public float minChargeForce;
    public float maxChargeForce;

    protected override void ExecuteFire()
    {
        float force = CalcForce();
        _recoilTarget.AddForce(-transform.forward * force, ForceMode.Impulse);
    }

    private float CalcForce()
    {
        return (maxChargeForce - minChargeForce) * ChargeRatio + minChargeForce;
    }

}
