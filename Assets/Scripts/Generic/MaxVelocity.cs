using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MaxVelocity : MonoBehaviour {

    public float maxVelocity;
    private Rigidbody _rigidBody;

	void Start()
	{
		_rigidBody = GetComponent<Rigidbody> ();
	}


	// Update is called once per frame
	void Update () {
        // Constant value is our max velocity magnitude it can be changed from here 
        if (_rigidBody.velocity.magnitude > maxVelocity)
        {
            _rigidBody.velocity = _rigidBody.velocity.normalized * maxVelocity;
        }
    }
}
