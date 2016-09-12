using UnityEngine;

public class Gun : MonoBehaviour 
{

    public Transform bulletSpawnTransform;
	public GameObject plasmaEffect;
	public Character character;
	public AudioClip plasmaSfx;
    public float shotDelay;
	public float damage;
    public float speed;

    private float _lastShotTime;
	private AudioSource _audio;

    void Awake()
    {
        _lastShotTime = Time.time;
		_audio = GetComponent<AudioSource> ();
    }

    void Update()
    {
        if (!Input.GetButton("Fire1")) return;
		if ((Time.time - _lastShotTime) < shotDelay) return;
        _lastShotTime = Time.time;
        Shoot();
    }

    public void Shoot()
    {
		var bullet = character.GetBullet();
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
        bullet.GetComponent<Rigidbody>().velocity = bV;
    }

    public Vector3 CalcShipVelocity(Vector3 bulletVelocity, float bulletMass)
    {
		var shipV = character.Velocity;
        Vector3 result = new Vector3();
		result.x = (shipV.x - bulletMass * bulletVelocity.x) / character.Mass;
		result.y = (shipV.y - bulletMass * bulletVelocity.y) / character.Mass;
		result.z = (shipV.z - bulletMass * bulletVelocity.z) / character.Mass;
        return result;
    }
}
