using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour 
{

    public GameObject primaryFireProjectilePrefab;
    public GameObject secondaryFireProjectilePrefab;
	public GameObject blackHoleExplosionPrefab;
	public AudioClip [] soundEffects;
	public Text fuelDepletedText;
	public Text fuelCountText;


    private int _maxVelocity;
    private Rigidbody _rigidBody;
	private FuelReservoir _fuelReservoir;
    private bool _cheatMode;


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
        _maxVelocity = 10;
        _rigidBody = GetComponent<Rigidbody>();
        _fuelReservoir = GetComponent<FuelReservoir>();
    }

	void Update()
	{
        //if (Input.GetKeyDown (KeyCode.B))
        //{
        //	ToggleCheatCode ();
        //}
        // Constant value is our max velocity magnitude it can be changed from here 
	    if(_rigidBody.velocity.magnitude > _maxVelocity)
        {
            _rigidBody.velocity = _rigidBody.velocity.normalized * _maxVelocity;
        }
		if (_fuelReservoir.fuelCount <= 0)
		{
			//fuelDepletedText.text = "You are out of Fuel!";
			//fuelDepletedText.color = Color.red;

		}
	}

	//Cheat code
	public bool ToggleCheatCode()
	{
        _cheatMode = !_cheatMode;
	    return _cheatMode;

	}


    public GameObject GetPrimaryFireProjectile()
    {
        if (!_cheatMode)
        {
            if (!_fuelReservoir.UseFuel(FuelReservoir.FuelUseType.PlasmaBullet))
            {
                return null;
            }
        }
        
        var bullet = Instantiate(primaryFireProjectilePrefab);
        Destroy(bullet, 5.0f);

        return bullet;
    }

    public GameObject GetSecondaryFireProjectile()
    {
        if (!_cheatMode)
        {
            if (!_fuelReservoir.UseFuel(FuelReservoir.FuelUseType.BlackHole))
            {
                return null;
            }
        }
        var bullet = Instantiate(secondaryFireProjectilePrefab);
        Destroy(bullet, 30.0f);

        return bullet;
    }

    public void AddFuel(int amount)
	{
        _fuelReservoir.AddFuel(amount);
		//fuelCountText.text = "Total Fuel : " + _fuelReservoir.fuelCount;
		Invoke ("RemoveFuelDepletedText", 1.0f);
		Invoke ("RemoveFuelText", 1.0f);
	}

    public void DestroyedByBlackHole()
    {
        AudioSource.PlayClipAtPoint(soundEffects[0], Camera.main.transform.position, 0.8f);
        Instantiate(blackHoleExplosionPrefab, transform.position, transform.rotation);
    }

    public void DestroyedByBullet()
    {
        AudioSource.PlayClipAtPoint(soundEffects[0], Camera.main.transform.position, 0.8f);
        Instantiate(blackHoleExplosionPrefab, transform.position, transform.rotation);
    }


    void RemoveFuelText()
	{
		//fuelCountText.text = "";
	}

	void RemoveFuelDepletedText()
	{
		//fuelDepletedText.text = "";
	}
	void OnDisable()
	{
	}
}
