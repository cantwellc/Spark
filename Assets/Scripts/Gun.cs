using UnityEngine;

public class Gun : MonoBehaviour {

    public Transform BulletSpawnTransform;
    public Ship Ship;
    public float ShotDelay;
	public float Damage;
    public float Speed;

    float _lastShotTime;

    void Awake()
    {
        _lastShotTime = Time.time;
    }

    void Update()
    {
        if (!Input.GetButton("Fire1")) return;
        if ((Time.time - _lastShotTime) < ShotDelay) return;
        _lastShotTime = Time.time;
        Shoot();
    }

    public void Shoot()
    {
        var bullet = Ship.GetBullet();
        if (bullet == null) return;
        bullet.transform.position = BulletSpawnTransform.position;
		bullet.GetComponent<ShipBulletCollision> ().SetDamage (Damage);
        // Shoot backwards with completely elastic colision to let unity physics engine handle
        // conservation of momentum.
        //bullet.GetComponent<Rigidbody>().velocity = Ship.Velocity + transform.TransformDirection(0.0f, 0.0f, -Speed);
        var bV = Ship.Velocity + transform.TransformDirection(0.0f, 0.0f, Speed);
        var sV = CalcShipVelocity(bV, bullet.GetComponent<Rigidbody>().mass);
        Ship.Velocity = sV;
        bullet.GetComponent<Rigidbody>().velocity = bV;
    }

    public Vector3 CalcShipVelocity(Vector3 bulletVelocity, float bulletMass)
    {
        var shipV = Ship.Velocity;
        Vector3 result = new Vector3();
        result.x = (shipV.x - bulletMass * bulletVelocity.x) / Ship.Mass;
        result.y = (shipV.y - bulletMass * bulletVelocity.y) / Ship.Mass;
        result.z = (shipV.z - bulletMass * bulletVelocity.z) / Ship.Mass;
        return result;
    }
}
