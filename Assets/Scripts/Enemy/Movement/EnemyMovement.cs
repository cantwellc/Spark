using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
	public Transform target;
	public float rotationSpeed;

	void FixedUpdate()
	{
        if(target)
		    lookAtTarget ();
	}
	//This makes the Enemy to turn to target(in our case player),slerp makes it so that the rotation is smooth
	void lookAtTarget()
	{
		transform.rotation = Quaternion.Slerp(transform.rotation,
			Quaternion.LookRotation(target.position - transform.position), 
			rotationSpeed*Time.deltaTime);
	}
}
