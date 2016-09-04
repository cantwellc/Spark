using UnityEngine;
using System.Collections;

public class RotateObstacle : MonoBehaviour {

    public float yRotation=3.0f;
    Vector3 rot;

	// Use this for initialization
	void Start () {
	    rot = new Vector3(0.0f,yRotation,0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rot);
	}
}
