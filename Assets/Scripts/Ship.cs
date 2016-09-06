using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Ship : MonoBehaviour {

    public GameObject BulletPrefab;
    public int AmmoCount = 10;
	public Text AmmoText;

    Rigidbody _rigidBody;

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
		InvokeRepeating("addBullet", 2.0f,2.0f);
    }

	void addBullet()
    {
        AmmoCount+=2;
		AmmoText.text = "Ammo Left " + AmmoCount;
    }

    public GameObject GetBullet()
    {
		
		if (AmmoCount <= 0)
		{
			return null;
		}
        var bullet = Instantiate(BulletPrefab);
        AmmoCount--;
		AmmoText.text = "Ammo Left " + AmmoCount;
        Destroy(bullet, 5.0f);

        return bullet;
    }
}
