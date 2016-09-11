using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour 
{

    public GameObject bulletPrefab;
	public Text fuelDepletedText;
	public Text fuelCountText;

    private Rigidbody _rigidBody;
    private FuelReservoir _fuelReservoir;

    public Vector3 Velocity
    {
        get
        {
            return _rigidBody.velocity;
        }
        set
        {
            _rigidBody.velocity = value;
        }
    }
		
    public float Mass
    {
        get
        {
            return _rigidBody.mass;
        }
    }

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _fuelReservoir = GetComponent<FuelReservoir>();
    }

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.B))
		{
			ToggleCheatCode ();
		}
			
		if (_fuelReservoir.fuelCount <= 0)
		{
			fuelDepletedText.text = "You are out of Fuel!";
			fuelDepletedText.color = Color.red;

		}
	}

	//Cheat code
	public void ToggleCheatCode()
	{
		RemoveFuelDepletedText ();
		if (_fuelReservoir.fuelCount >= 300)
		{
            _fuelReservoir.fuelCount = 10;
			fuelCountText.text = "Total Fuel(Cheat Disabled) : " + _fuelReservoir.fuelCount;
		} 
		else
		{
            _fuelReservoir.fuelCount = 5550;
			fuelCountText.text = "Total Fuel(Cheat Enabled) : " + _fuelReservoir.fuelCount;
		}
		Invoke ("RemoveFuelText", 1.0f);
	}


    public GameObject GetBullet()
    {
		
		if (!_fuelReservoir.UseFuel(FuelReservoir.FuelUseType.PlasmaBullet))
		{
			return null;
		}
		var bullet = Instantiate(bulletPrefab);
        Destroy(bullet, 5.0f);

        return bullet;
    }

	public void AddFuel(int amount)
	{
        _fuelReservoir.AddFuel(amount);
		fuelCountText.text = "Total Fuel : " + _fuelReservoir.fuelCount;
		Invoke ("RemoveFuelDepletedText", 1.0f);
		Invoke ("RemoveFuelText", 1.0f);
	}

	void RemoveFuelText()
	{
		fuelCountText.text = "";
	}

	void RemoveFuelDepletedText()
	{
		fuelDepletedText.text = "";
	}
}
