﻿using UnityEngine;
using System.Collections;

public class CharacterAnimationPlay : MonoBehaviour {

	private bool _lockRotation = false;
	public float rotationY = -90;
	public float MovementSpeed = 5000;
	private bool _collided = false;
	public bool levelStart = true;
	public bool playChargeEffect = false;
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_lockRotation)
		{
			lockRotation ();
			Character.current.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward * -MovementSpeed);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Character")
		{
			
			if (!_collided)
			{
				_collided = true;
				if (playChargeEffect)
				{
					Character.current.GetComponent<VFX_Player> ().PlayEffect ();
				}
				lockRotation ();
				Character.current.GetComponentInChildren<Gun> ().DisableInput ();

				_lockRotation = true;
				if(levelStart)
				{
					Invoke ("ReEnableInput", 4.0f);
				}
			}
		}
	}

	void lockRotation()
	{
		Character.current.transform.rotation =  Quaternion.Euler (0, rotationY, 0);
	}

	public void ReEnableInput()
	{
		_lockRotation = false;
		Character.current.GetComponentInChildren<Gun> ().EnableInput ();
	}
}
