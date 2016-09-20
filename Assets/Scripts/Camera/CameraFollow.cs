using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{

	public Transform targetLocation;

	private Vector3 _offset;

	// Use this for initialization
	void Start () 
	{	//Offset between the players position and the cameras position
		transform.position = new Vector3(targetLocation.position.x,transform.position.y,targetLocation.position.z);
		_offset = transform.position - targetLocation.position;
	}

	void LateUpdate()
	{
		/*We are gonna move to a new location now because player might have moved
		 * Offset ensures that we keep our distance from the player*/
		Vector3 newPosition = targetLocation.position + _offset;
		//TODO:Make the camera movement smoother
		transform.position = newPosition;
	}
}
