using System;
using UnityEngine;

public class Gun : MonoBehaviour 
{

    public Transform targetMarker;
    public Transform bulletSpawnTransform;
	public GameObject plasmaEffect;
	public Character character;
	public AudioClip plasmaSfx;
    public float primaryFireDelay;
    public float secondaryFireDelay;
	public AudioClip chargingSFX;
	public float damage;
    public float speed;


    private float _lastPrimaryShotTime;
    private float _lastSecondaryShotTime;
	private AudioSource _audio;
    private Plane _mouseTargetPlane;
	private Rigidbody _characterRigidBody;
	private float _chargeScale;
	private float _maxCharge;
    private bool _isPause;

    void Awake()
    {
        _lastPrimaryShotTime = Time.time;
        _lastSecondaryShotTime = Time.time;
		_audio = GetComponent<AudioSource> ();
        _mouseTargetPlane = new Plane(transform.up, transform.position);
		_chargeScale = 0.0f;
		_maxCharge = 150.0f;
		_characterRigidBody = character.GetComponent<Rigidbody> ();

    }

    void OnEnable()
    {
        EventManager.StartListening(EventManager.Events.PAUSE_GAME, OnPause);
        EventManager.StartListening(EventManager.Events.RESUME_GAME, OnResume);
    }

    void OnDisable()
    {
        EventManager.StopListening(EventManager.Events.PAUSE_GAME, OnPause);
        EventManager.StopListening(EventManager.Events.RESUME_GAME, OnResume);
    }

    void Update()
    {
        if (!_isPause)
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


            //middle mouse button is holded
            if (Input.GetMouseButton(2))
            {

                if (_chargeScale == 0)
                {
                    AudioSource.PlayClipAtPoint(chargingSFX, Camera.main.transform.position, 1.0f);
                }

                if (_chargeScale < _maxCharge)
                {
                    _chargeScale += Time.deltaTime * 40;

                }
            }
            else
            {
                if (_chargeScale > 0)
                {

                    Ramming();

                }
                _chargeScale = 0;
            }
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
		var bV =  transform.TransformDirection(0.0f, 0.0f, speed);
        CalcShipVelocity(bV, bullet.GetComponent<Rigidbody>().mass);
		//character.Velocity = sV;
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
        float rayDistance;
        if (_mouseTargetPlane.Raycast(ray, out rayDistance))
            targetMarker.position = ray.GetPoint(rayDistance);
        return targetMarker.position;
    }

    public Vector3 CalcShipVelocity(Vector3 bulletVelocity, float bulletMass)
    {
		//var shipV = character.Velocity;
        Vector3 result = new Vector3();
        result.x = -bulletMass * bulletVelocity.x;//(shipV.x - bulletMass * bulletVelocity.x) / character.Mass;
        result.y = 0;//(shipV.y - bulletMass * bulletVelocity.y) / character.Mass;
        result.z = -bulletMass * bulletVelocity.z;//(shipV.z - bulletMass * bulletVelocity.z) / character.Mass;

        character.GetComponent<Rigidbody>().AddForce(result, ForceMode.Impulse);

        return result;
    }

	void Ramming()
	{
		character.maxVelocity = 50;
		character.Velocity *= 2;

		character.ramEffect.Play ();
		character.Velocity += transform.forward * _chargeScale * -1;

		character.transform.localScale = new Vector3 (0.57f, 0.6f, 0.6f);

		Invoke ("StopRamming", 0.3f);
		Invoke ("StopParticles", 0.5f);
	}
	void StopRamming()
	{
		character.maxVelocity = 10;
		character.transform.localScale = new Vector3 (0.6f, 0.6f, 0.6f);

		character.Velocity = transform.forward * -2;
	}
	void StopParticles()
	{
		character.ramEffect.Stop ();
	}

    void OnPause()
    {
        _isPause = true;
    }

    void OnResume()
    {
        _isPause = false;
    }
}
