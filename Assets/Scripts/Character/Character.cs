using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour 
{

    public GameObject bulletPrefab;
    public int fuelCount = 10;
	public Text fuelDepletedText;
	public Text fuelCountText;

    private Rigidbody _rigidBody;

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

    }

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.B))
		{
			ToggleCheatCode ();
		}
			
		if (fuelCount <= 0)
		{
			fuelDepletedText.text = "You are out of Fuel!";
			fuelDepletedText.color = Color.red;

		}
	}

	//Cheat code
	public void ToggleCheatCode()
	{
		RemoveFuelDepletedText ();
		if (fuelCount >= 300)
		{
			fuelCount = 10;
			fuelCountText.text = "Total Fuel(Cheat Disabled) : " + fuelCount;
		} 
		else
		{
			fuelCount = 5550;
			fuelCountText.text = "Total Fuel(Cheat Enabled) : " + fuelCount;
		}
		Invoke ("RemoveFuelText", 1.0f);
	}


    public GameObject GetBullet()
    {
		
		if (fuelCount <= 0)
		{
			return null;
		}
		var bullet = Instantiate(bulletPrefab);
		fuelCount--;
        Destroy(bullet, 5.0f);

        return bullet;
    }

	public void AddFuel(int amount)
	{
		fuelCount += amount;
		fuelCountText.text = "Total Fuel : " + fuelCount;
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
