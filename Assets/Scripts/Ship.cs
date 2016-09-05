using UnityEngine;
using System.Collections.Generic;
using System;

public class Ship : MonoBehaviour {

    public GameObject BulletPrefab;
    public int AmmoCount = 10;

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
    }

    void addBullet()
    {
        AmmoCount++;
    }

    public GameObject GetBullet()
    {
		if (AmmoCount <= 0) return null;
        var bullet = Instantiate(BulletPrefab);
        AmmoCount--;
        Destroy(bullet, 5.0f);
        Invoke("addBullet",5.0f);
        return bullet;
    }
}
