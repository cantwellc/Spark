using UnityEngine;
using System.Collections;

public class IncreaseSpeedOnCollision : MonoBehaviour {

	private Rigidbody _rigidBody;
	private bool _init = false;
	public float force;

	void Start()
	{
		
	}




	// Use this for initialization
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Character")
		{
			_rigidBody = Character.current.GetComponent<Rigidbody> ();
			//AudioManager.instance.Play("speedAura");
			AudioManager.instance.Play("speedAura");
			Vector3 speedForce = (_rigidBody.velocity.normalized * force) ;
			_rigidBody.AddForce (speedForce, ForceMode.Force);
		}
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            _rigidBody = Character.current.GetComponent<Rigidbody>();
            //AudioManager.instance.Play("speedAura");
            AudioManager.instance.Play("speedAura");
            Vector3 speedForce = (_rigidBody.velocity.normalized * force);
            _rigidBody.AddForce(speedForce, ForceMode.Force);
        }
    }
}
