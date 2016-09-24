using UnityEngine;
using System.Collections;

public class ExplodingDrone : MonoBehaviour {

    public float moveForce;

    Rigidbody _rigidBody;
	// Use this for initialization
	void Start () {
        _rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Transform targetTransform = Character.current.transform;

        Vector3 dir = (targetTransform.position - transform.position).normalized;
        _rigidBody.AddForce(dir * moveForce);

        Quaternion dest = Quaternion.LookRotation(dir.normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, dest, 1);
    }
    
    void OnCollisionEnter()
    {
    }
}
