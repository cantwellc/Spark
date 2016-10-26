using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ChasePlayer : MonoBehaviour {

	public float initialSpeed;
	public float afterFirstChaseSpeed;
	public Transform pedestalLocation;





	private float _speed;
	private Vector3 _targetPosition;
	private bool _follow = true;
	private bool _prepare_to_follow = true;
	private NavMeshAgent _navMeshAgent;
	void Start () 
	{

		_speed = initialSpeed;
		_navMeshAgent = GetComponent<NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update () 
	{


		if (CharacterCloseToPedestal ())
		{
			_follow = false;
			Destroy (gameObject);
		}


		if (_follow)
		{
			
			if (Character.current != null)
			{
				float step = initialSpeed * Time.deltaTime;
				_targetPosition = new Vector3 (Character.current.transform.position.x - 1.0f, transform.position.y, Character.current.transform.position.z);
				_navMeshAgent.SetDestination (_targetPosition);
				transform.LookAt (Character.current.transform.position);
				//Quaternion rotationAngle = Quaternion.LookRotation (_targetPosition - transform.position);
				//transform.rotation = Quaternion.Slerp (transform.rotation, rotationAngle, Time.deltaTime * 1);
				//transform.position = Vector3.MoveTowards (transform.position, _targetPosition, step);
				if (VeryCloseOnXZ ())
				{
					GetComponent<AreaAttack> ().Attack ();
					_follow = false;
					_prepare_to_follow = true;
				}
			}
		}
		else
		{
			//This was aimed for the case for chaser to follow you second time
		}


	}

	public bool VeryCloseOnXZ()
	{
		if (Character.current != null)
		{
			Vector2 characterXZ = new Vector2 (Character.current.transform.position.x, Character.current.transform.position.z);
			Vector2 currentXZ = new Vector2 (transform.position.x, transform.position.z);

			if (Vector2.Distance (characterXZ, currentXZ) <= 1.9)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	void Follow()
	{
		GetComponent<Renderer> ().enabled = true;
		transform.position = new Vector3 (transform.position.x - Random.Range (120, 150), transform.position.y, transform.position.z - Random.Range (120, 150));
		AudioManager.instance.Play ("evilLaugh");
		_speed = afterFirstChaseSpeed;
		_follow = true;
	}

	bool CharacterCloseToPedestal()
	{
		if (Character.current != null)
		{
			Vector2 characterXZ = new Vector2 (Character.current.transform.position.x, Character.current.transform.position.z);
			Vector2 pedestalXZ = new Vector2 (pedestalLocation.position.x, pedestalLocation.position.z);
			if (Vector2.Distance (characterXZ, pedestalXZ) <= 5.5f)
			{
				return true;
			}
			return false;
		}
		return false;

	}
}
