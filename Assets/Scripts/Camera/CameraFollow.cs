using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{

    public static CameraFollow mainCamera;

	public Transform targetLocation;
    public Transform targetLocation2;
	public bool bossLevel = false;

    public float speed;
	public float cameraPlayerFollowCoefficient = 1.0f;

	private Vector3 _offset;
	private bool _shaking = false;


	// Use this for initialization
	protected virtual void Start () 
	{	//Offset between the players position and the cameras position
        mainCamera = this;
		if (!bossLevel)
		{
			transform.position = new Vector3 (transform.position.x, 24.0f, transform.position.z);
		}
		/*if (targetLocation == null)
        {
            if (Character.current == null)
                return;
            targetLocation = Character.current.transform;
        }
		transform.position = new Vector3(targetLocation.position.x,transform.position.y,targetLocation.position.z);
        _offset = transform.position - targetLocation.position;*/
	}

    void Awake()
    {

    }

	void LateUpdate()
	{
		if (!_shaking)
		{
			if (targetLocation == null)
			{
				if (Character.current == null)
					return;
				targetLocation = Character.current.transform;
                transform.position = new Vector3(targetLocation.position.x, transform.position.y, targetLocation.position.z);
                _offset = transform.position - targetLocation.position;
                print(_offset);
            }
			Vector3 newPosition;
			/*We are gonna move to a new location now because player might have moved
		 * Offset ensures that we keep our distance from the player*/
			if (targetLocation2 == null)
			{
				newPosition = targetLocation.position + _offset;
			} else
			{
				newPosition = (targetLocation.position  + targetLocation2.position * cameraPlayerFollowCoefficient) / 2.0f + _offset;
				if ((newPosition - transform.position).magnitude > 2.0f)
				{
					newPosition = Vector3.MoveTowards (transform.position, newPosition, speed * Time.deltaTime);
				}
			}
			//TODO:Make the camera movement smoother
			transform.position = newPosition;
		}
	}

	public void EnableShaking()
	{
		_shaking = true;
	}
	public void DisableShaking()
	{
		_shaking = false;
	}
}
