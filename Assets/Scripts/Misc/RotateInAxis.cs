using UnityEngine;
using System.Collections;

public class RotateInAxis : MonoBehaviour {

	public float yRotation;
	public float xRotation;
	public float zRotation;
	private Vector3 _rot;

	// Use this for initialization
	void Start () 
	{
		_rot = new Vector3(xRotation,yRotation,zRotation);
	}

	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(_rot);
	}
}
