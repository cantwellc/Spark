using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public abstract class FireBehavior : MonoBehaviour {
    public UnityEvent OnStartCharge;
    public UnityEvent OnFinishCharge;
    public UnityEvent OnFire;
	public UnityEvent CantFire;

    public GameObject projectilePrefab;
    public float damage;
    public float speed;

    public bool canCharge;
    public float maxChargeTime;
    public float minChargeFuelCost;
    public float maxChargeFuelCost;


    protected float _chargeRatio;
    public float ChargeRatio
    {
        get
        {
            _chargeRatio = CalcChargeRatio();
            return _chargeRatio;
        }
    }

    protected float _startChargeTime;
    protected Rigidbody _recoilTarget;
    protected Transform _spawnTransform;
    protected FuelReservoir _fuelReservoir;

    void Awake()
    {
        _startChargeTime = -1.0f;
    }

    public void StartCharge()
    {
        if (!canCharge) return;
		if (minChargeFuelCost > _fuelReservoir.fuelCount)
		{
			return;
		}

        _startChargeTime = Time.time;
        OnStartCharge.Invoke();
    }

    public void InitFireBehavior(Rigidbody recoilTarget, Transform spawnTransform, FuelReservoir fuelReservoir)
    {
        _recoilTarget = recoilTarget;
        _spawnTransform = spawnTransform;
        _fuelReservoir = fuelReservoir;
    }
	
	private float GetFuelCost()
	{
		_chargeRatio = CalcChargeRatio();
		return CalcFuelCost(_chargeRatio);			
	}

    public void Fire()
    {
		float fuelCost = GetFuelCost ();
		if (_fuelReservoir.fuelCount <= minChargeFuelCost)
		{
			CantFire.Invoke ();
			return;
		}
		_fuelReservoir.UseFuel(fuelCost);
        ExecuteFire();
        OnFire.Invoke();
    }

    protected abstract void ExecuteFire();

    private float CalcFuelCost(float chargeRatio)
    {
        return (maxChargeFuelCost - minChargeFuelCost) * chargeRatio + minChargeFuelCost;
    }

    private float CalcChargeRatio()
    {
        if (!canCharge) return 1.0f;
        return Math.Min((Time.time - _startChargeTime) / maxChargeTime, 1.0f);
    }

    void Update()
    {
        if (_startChargeTime == -1.0f) return;
        if (Time.time - _startChargeTime < maxChargeTime) return;
        OnFinishCharge.Invoke();
    }
}
