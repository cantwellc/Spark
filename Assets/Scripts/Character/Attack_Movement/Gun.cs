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
	private bool _inputEnabled = true;

    void Awake()
    {
        _lastPrimaryShotTime = Time.time;
        _lastSecondaryShotTime = Time.time;

        primaryFireBehavior.InitFireBehavior(recoilTarget, bulletSpawnTransform, fuelReservoir);
        secondaryFireBehavior.InitFireBehavior(recoilTarget, bulletSpawnTransform, fuelReservoir);

//        _mouseTargetPlane = new Plane(transform.up, transform.position);

    }

	void Start()
	{
		AudioManager.instance.Play ("moveEnd");
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
		if (_inputEnabled)
		{
			if (Input.GetMouseButtonDown (0))
				AudioManager.instance.Play ("moveStart");

			if (Input.GetMouseButtonUp (0))
				AudioManager.instance.Play ("moveEnd");

			if (Input.GetMouseButton (0))
			{
				PrimaryFire ();
			}
			if (Input.GetMouseButtonDown (1))
			{
				secondaryFireBehavior.StartCharge ();
			} else if (Input.GetMouseButtonUp (1))
			{
				SecondaryFire ();
			}
		}
    }

    public void PrimaryFire()
    {

        if ((Time.time - _lastPrimaryShotTime) < primaryFireDelay) return;
        primaryFireBehavior.Fire();



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
      
    }


	public void DisableInput()
	{
		_inputEnabled = false;
	}
	public void EnableInput()
	{
		_inputEnabled = true;
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
