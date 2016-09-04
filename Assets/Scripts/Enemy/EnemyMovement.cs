using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	public Transform Target;
	public float RotationSpeed;

	void FixedUpdate()
	{
		lookAtTarget ();
	}
	//This makes the Enemy to turn to target(in our case player),slerp makes it so that the rotation is smooth
	void lookAtTarget()
	{
		transform.rotation = Quaternion.Slerp(transform.rotation,
			Quaternion.LookRotation(Target.position - transform.position), 
			RotationSpeed*Time.deltaTime);
	}
}
