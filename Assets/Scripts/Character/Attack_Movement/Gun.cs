using System;
using UnityEngine;

public class Gun : MonoBehaviour 
{
    public Transform mouseTargetPlane;
    public Transform bulletSpawnTransform;
	public GameObject plasmaEffect;
	public Character character;
	public AudioClip plasmaSfx;
    public float primaryFireDelay;
    public float secondaryFireDelay;
	public float damage;
    public float speed;

    private float _lastPrimaryShotTime;
    private float _lastSecondaryShotTime;
	private AudioSource _audio;

    void Awake()
    {
        _lastPrimaryShotTime = Time.time;
        _lastSecondaryShotTime = Time.time;
		_audio = GetComponent<AudioSource> ();
    }

    void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            if ((Time.time - _lastPrimaryShotTime) < primaryFireDelay) return;
            PrimaryFire();
        }
        if (Input.GetButton("Fire2"))
        {
            if ((Time.time - _lastSecondaryShotTime) < secondaryFireDelay) return;
            SecondaryFire();
        }
    }

    public void PrimaryFire()
    {
		var bullet = character.GetPrimaryFireProjectile();
        if (bullet == null) return;

		_audio.PlayOneShot (plasmaSfx);
		GameObject plasmaEffectInstance=Instantiate (plasmaEffect, bulletSpawnTransform.position, bulletSpawnTransform.rotation) as GameObject;
		Destroy (plasmaEffectInstance, 2.0f);

		bullet.transform.position = bulletSpawnTransform.position;
		bullet.GetComponent<CharacterBulletCollision> ().SetDamage (damage);
        // Shoot backwards with completely elastic colision to let unity physics engine handle
        // conservation of momentum.
        //bullet.GetComponent<Rigidbody>().velocity = Ship.Velocity + transform.TransformDirection(0.0f, 0.0f, -Speed);
		var bV = character.Velocity + transform.TransformDirection(0.0f, 0.0f, speed);
        var sV = CalcShipVelocity(bV, bullet.GetComponent<Rigidbody>().mass);
		character.Velocity = sV;
        bV.y = 0;
        bullet.GetComponent<Rigidbody>().velocity = bV;
        _lastPrimaryShotTime = Time.time;
    }

    /// <summary>
    /// Implement Secondary Fire Functionality here
    /// </summary>
    private void SecondaryFire()
    {
        Vector3 target = GetTarget();
        var b = character.GetSecondaryFireProjectile();
        b.transform.position = bulletSpawnTransform.position;
        var targetVector = target - b.transform.position;
        var flightTime = targetVector.magnitude / speed;
        var bhb = b.GetComponent<BlackHoleBomb>();
        bhb.target = target;
        bhb.flightTime = flightTime;

        b.GetComponent<Rigidbody>().velocity = targetVector.normalized * speed;
        _lastSecondaryShotTime = Time.time;

//        b.transform.position = target;
    }

    Vector3 GetTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float delta = ray.origin.y - mouseTargetPlane.transform.position.y;
        Vector3 dirNorm = ray.direction / ray.direction.y;
        Vector3 IntersectionPos = ray.origin - dirNorm * delta;
        return IntersectionPos;
    }

    public Vector3 CalcShipVelocity(Vector3 bulletVelocity, float bulletMass)
    {
		var shipV = character.Velocity;
        Vector3 result = new Vector3();
		result.x = (shipV.x - bulletMass * bulletVelocity.x) / character.Mass;
        result.y = 0;//(shipV.y - bulletMass * bulletVelocity.y) / character.Mass;
		result.z = (shipV.z - bulletMass * bulletVelocity.z) / character.Mass;
        return result;
    }
}
