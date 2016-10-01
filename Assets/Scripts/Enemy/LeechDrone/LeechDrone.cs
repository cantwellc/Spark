using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class LeechDrone : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public float startFollowingWhenDistanceIs;
	public float stopLeechingAfterDistance;
	public float getDamageWhenCloserThan;
	public Health health;
	private bool _follow = true;
	private bool _leeched = false;
	private float _originalDrag;
	private Rigidbody _rigidbody;
	private Rigidbody _characterRigidbody;
	void Start () 
	{
		_rigidbody = GetComponent<Rigidbody> ();
		_characterRigidbody = Character.current.GetComponent<Rigidbody> ();
		_originalDrag = _rigidbody.drag;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Follow ();

	}

	void Follow()
	{
		if (Character.current == null)
		{
			return;
		} 
		else
		{
			float distance = Vector3.Distance (Character.current.transform.position, transform.position);
			//When the drone is far from the character
			if (distance > startFollowingWhenDistanceIs)
			{
				if (_leeched)
				{
					_characterRigidbody.drag = _originalDrag;
				}

				//This means the drone is leeched but we are now escaped the leeching
				if (_leeched && distance > stopLeechingAfterDistance)
				{
					_leeched = false;
					_follow = false;

					health.TakeDamage (500);

				}
				//It just follows normally
				if (_follow)
				{
					transform.position = Vector3.MoveTowards (transform.position, Character.current.transform.position, speed * Time.deltaTime);
				}
			}
			//When the drone is close to the character
			else
			{
				//Drone starts to leech if it is close
				if (_follow)
				{
					_leeched = true;

					//It attacks you when it is close
					if (distance <= getDamageWhenCloserThan)
					{
						Attack ();

					}
					//Reverts to the original speed
					else
					{
						_characterRigidbody.drag = _originalDrag;
					}

				} 
			}


		}
	}

	void Attack()
	{
		_characterRigidbody.drag = _characterRigidbody.drag + 2f * Time.deltaTime;
		//Debug.Log ("Attacking");
	}

}
