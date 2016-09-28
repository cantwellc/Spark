using System;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour 
{
    public FireBehavior primaryFireBehavior;
    public FireBehavior secondaryFireBehavior;
    public FuelReservoir fuelReservoir;

    public float primaryFireDelay;
    public float secondaryFireDelay;

    private float _lastPrimaryShotTime;
    private float _lastSecondaryShotTime;

//    public Transform targetMarker;
    public Transform bulletSpawnTransform;
    public Rigidbody recoilTarget;
//    public GameObject plasmaEffect;



    //   private Plane _mouseTargetPlane;
    //private Rigidbody _characterRigidBody;
    //private float _chargeScale;
    //private float _maxCharge;
    private bool _isPause;

    void Awake()
    {
        _lastPrimaryShotTime = Time.time;
        _lastSecondaryShotTime = Time.time;

        primaryFireBehavior.InitFireBehavior(recoilTarget, bulletSpawnTransform, fuelReservoir);
        secondaryFireBehavior.InitFireBehavior(recoilTarget, bulletSpawnTransform, fuelReservoir);

//        _mouseTargetPlane = new Plane(transform.up, transform.position);

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
        if (_isPause) return;
        if (Input.GetMouseButton(0))
        {
            PrimaryFire();
        }
        if (Input.GetMouseButtonDown(1))
        {
            secondaryFireBehavior.StartCharge();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            SecondaryFire();
        }
    }

    public void PrimaryFire()
    {
//        Debug.Log("Primary Fire");
        if ((Time.time - _lastPrimaryShotTime) < primaryFireDelay) return;
        primaryFireBehavior.Fire();

//		GameObject plasmaEffectInstance=Instantiate (plasmaEffect, bulletSpawnTransform.position, bulletSpawnTransform.rotation) as GameObject;
//		Destroy (plasmaEffectInstance, 2.0f);

        _lastPrimaryShotTime = Time.time;
    }

    /// <summary>
    /// Implement Secondary Fire Functionality here
    /// </summary>
    private void SecondaryFire()
    {
        //        Debug.Log("Secondary Fire");
        secondaryFireBehavior.Fire();
        _lastSecondaryShotTime = Time.time;
        //if ((Time.time - _lastSecondaryShotTime) < secondaryFireDelay) return;
        //secondaryFireBehavior.Fire();

        //Vector3 target = GetTarget();
        //var b = character.GetSecondaryFireProjectile();
        //b.transform.position = bulletSpawnTransform.position;
        //var targetVector = target - b.transform.position;
        //var flightTime = targetVector.magnitude / speed;
        //var bhb = b.GetComponent<BlackHoleBomb>();
        //bhb.target = target;
        //bhb.flightTime = flightTime;

        //b.GetComponent<Rigidbody>().velocity = targetVector.normalized * speed;
        //_lastSecondaryShotTime = Time.time;

//        b.transform.position = target;
    }

    //Vector3 GetTarget()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    float rayDistance;
    //    if (_mouseTargetPlane.Raycast(ray, out rayDistance))
    //        targetMarker.position = ray.GetPoint(rayDistance);
    //    return targetMarker.position;
    //}
    
    

    void OnPause()
    {
        _isPause = true;
    }

    void OnResume()
    {
        _isPause = false;
    }
}
