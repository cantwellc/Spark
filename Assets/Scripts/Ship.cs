using UnityEngine;
using System.Collections.Generic;
using System;

public class Ship : MonoBehaviour {

    public GameObject BulletPrefab;
    public int AmmoCount = 10;

    public Vector3 Velocity
    {
        get
        {
            return GetComponent<Rigidbody>().velocity;
        }
    }

    void addBullet()
    {
        AmmoCount++;
    }

    public GameObject GetBullet()
    {
		if (AmmoCount <= 0) return null;
        var bullet = Instantiate(BulletPrefab);
        //GetComponent<Rigidbody>().mass -= bullet.gameObject.GetComponent<Rigidbody>().mass;
        AmmoCount--;
        Destroy(bullet, 5.0f);
        Invoke("addBullet",5.0f);
        return bullet;
    }
}
