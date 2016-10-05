using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class SlowDownPhysics : MonoBehaviour {

    public float slowSpeedThreshold;

    float _originalDrag;
    Rigidbody _rigidBody;
    bool _secondFrame = false;

    // Use this for initialization
    void Start () {
        _rigidBody = GetComponent<Rigidbody>();
        _originalDrag = _rigidBody.drag;
	}
	
    public void SlowDown(float force)
    {
        Vector3 velocity = _rigidBody.velocity;
        if(velocity.magnitude > slowSpeedThreshold)
        {
            Vector3 forceToApply = -(velocity.normalized) * force *2;
            _rigidBody.AddForce(forceToApply, ForceMode.Force);
        }
        //_rigidBody.drag = _rigidBody.drag * slowRate;
    }

    void FixedUpdate()
    {
    }
	// Update is called once per frame
	void Update ()
    {
        /*if(_secondFrame)
        {
            _rigidBody.drag = _originalDrag;
            _secondFrame = false;
        }
        else
        {
            _secondFrame = true;
        }*/
    }
}
