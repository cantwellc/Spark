using UnityEngine;
using System.Collections.Generic;

public class Gun : MonoBehaviour {

    public Transform BulletSpawnTransform;
    public Ship Ship;

    public float Speed;

    public void Shoot()
    {
        var bullet = Ship.GetBullet();
        if (bullet == null) return;
        bullet.transform.position = BulletSpawnTransform.position;
        // Shoot backwards with completely elastic colision to let unity physics engine handle
        // conservation of momentum.
        bullet.GetComponent<Rigidbody>().velocity = Ship.Velocity + transform.TransformDirection(0.0f, 0.0f, -Speed);
    }
}
