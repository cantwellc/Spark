using UnityEngine;
using System.Collections;

public class RotateObstacle : MonoBehaviour 
{

    public float yRotation=3.0f;
	private Vector3 _rot;

	// Use this for initialization
	void Start () 
	{
	    _rot = new Vector3(0.0f,yRotation,0.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
        transform.Rotate(_rot);
	}
}
