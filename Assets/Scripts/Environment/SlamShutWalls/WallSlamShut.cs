using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class WallSlamShut : MonoBehaviour {

	public Transform slamShutCenter;
	public Transform openTransform;
	public bool slamShutting;
	public bool opening;
	public SlamShutWallsController slamShutWallsController;
	private float _waitBeforeOpening;
	private float _waitAfterOpening;
	private float _slamShuttingSpeed;
	private float _openingSpeed;
	private bool _init = false;

	private bool canSound = true;



	public UnityEvent OnStartMoving;
	public UnityEvent OnStopMoving;

	// Use this for initialization

	
	// Update is called once per frame


	void Awake()
	{
		_waitBeforeOpening = slamShutWallsController.delayOfOpeningAfterSlamming;
		_waitAfterOpening = slamShutWallsController.delayOfSlammingAfterOpening;
		_slamShuttingSpeed = slamShutWallsController.slamShuttingSpeed;
		_openingSpeed = slamShutWallsController.openingSpeed;
	}


	void Update () 
	{

		if (!_init && slamShutWallsController!=null)
		{
			
			_init = true;
		}


		if (slamShutting)
		{
			if (transform.position == slamShutCenter.position)
			{
				if (canSound)
					AudioManager.instance.Play ("wallSlam", gameObject);
				slamShutting = false;
				StartOpening ();
				return;
			}

			var step = _slamShuttingSpeed * Time.deltaTime;
			//var forward = transform.worldToLocalMatrix.MultiplyVector (transform.forward);
			transform.position = Vector3.MoveTowards(transform.position,slamShutCenter.position,step);
			//transform.Translate (forward * step);
		} 
		if (opening)
		{
			
			if (transform.position == openTransform.position)
			{
				StopOpening ();
			}

			var step = _openingSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, openTransform.position, step);
				
		}
	}



	public void StopShutting()
	{
		slamShutting = false;
		OnStopMoving.Invoke();
		//Wait waitBeforeOpening seconds before starting to open
		Invoke ("StartOpening", _waitBeforeOpening);
	}

	public void StartOpening()
	{
		opening = true;
	}

	public void StopOpening()
	{
		canSound = true;
		opening = false;
		//Wait waitAfterOpening seconds before starting to shut
		Invoke ("StartShutting", _waitAfterOpening);

	}

	public void StartShutting()
	{
		slamShutting = true;
		OnStartMoving.Invoke ();
	}

	public void LastSlam()
	{
		slamShutting = true;
		_slamShuttingSpeed = 50;
	}
}
