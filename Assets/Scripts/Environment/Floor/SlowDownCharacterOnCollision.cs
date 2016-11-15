using UnityEngine;
using System.Collections;

public class SlowDownCharacterOnCollision : MonoBehaviour
{

    public float force;
    public float slowDownThreshold;
    private Rigidbody _rigidBody;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
		AudioManager.instance.Play("slowAura");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
			_rigidBody = Character.current.GetComponent<Rigidbody>();
            if (_rigidBody.velocity.magnitude > slowDownThreshold)
            {
                Vector3 reverseForce = (_rigidBody.velocity.normalized * force) * -3;
                _rigidBody.AddForce(reverseForce, ForceMode.Force);
            }

        }
    }
    void OnTriggerExit(Collider other)
    {
        
    }
}