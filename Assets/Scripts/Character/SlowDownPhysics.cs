using UnityEngine;
using System.Collections;

public class SlowDownPhysics : MonoBehaviour {

    float _originalDrag;
    Rigidbody _rigidBody;
    bool _secondFrame = false;

    // Use this for initialization
    void Start () {
        _rigidBody = GetComponent<Rigidbody>();
        _originalDrag = _rigidBody.drag;
	}
	
    public void SlowDown(float slowRate)
    {
        _rigidBody.drag = _rigidBody.drag * slowRate;
    }

    void FixedUpdate()
    {
    }
	// Update is called once per frame
	void Update ()
    {
        if(_secondFrame)
        {
            _rigidBody.drag = _originalDrag;
            _secondFrame = false;
        }
        else
        {
            _secondFrame = true;
        }
    }
}
