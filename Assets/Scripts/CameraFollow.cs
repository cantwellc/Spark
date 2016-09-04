using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform TargetLocation;

	private Vector3 offset;

	// Use this for initialization
	void Start () 
	{	//Offset between the players position and the cameras position
		offset = transform.position - TargetLocation.position;
	}

	void LateUpdate()
	{
		/*We are gonna move to a new location now because player might have moved
		 * Offset ensures that we keep our distance from the player*/
		Vector3 newPosition = TargetLocation.position + offset;
		//TODO:Make the camera movement smoother
		transform.position = newPosition;
	}
}
