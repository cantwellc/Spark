using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {

    public float velocityX;
    public float velocityZ;
    private Rigidbody _rb;

	// Use this for initialization
	void Start () {
        _rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        _rb.velocity = new Vector3(velocityX,0,velocityZ);
	}
}
