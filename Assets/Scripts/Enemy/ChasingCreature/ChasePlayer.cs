using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour {

	public float initialSpeed;
	public float afterFirstChaseSpeed;
	private float _speed;
	private Vector3 _targetPosition;
	private bool follow = true;
	private bool _prepare_to_follow = true;
	void Start () 
	{

		_speed = initialSpeed;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (follow)
		{
			float step = initialSpeed * Time.deltaTime;
			_targetPosition = new Vector3 (Character.current.transform.position.x - 1.0f, transform.position.y, Character.current.transform.position.z);
			transform.position = Vector3.MoveTowards (transform.position, _targetPosition, step);
			if (VeryCloseOnXZ())
			{
				GetComponent<AreaAttack> ().Attack ();
				follow = false;
				_prepare_to_follow = true;
			}
		}
		else
		{
			if (_prepare_to_follow)
			{
				
				GetComponent<Renderer> ().enabled = false;
				Invoke ("Follow", 10.0f);
				_prepare_to_follow = false;
			}
		}


	}

	public bool VeryCloseOnXZ()
	{
		Vector2 characterXZ = new Vector2 (Character.current.transform.position.x, Character.current.transform.position.z);
		Vector2 currentXZ = new Vector2 (transform.position.x, transform.position.z);

		if (Vector2.Distance (characterXZ, currentXZ) <=1.2)
		{
			return true;
		}
		return false;
	}

	void Follow()
	{
		GetComponent<Renderer> ().enabled = true;
		transform.position = new Vector3 (transform.position.x - Random.Range (120, 150), transform.position.y, transform.position.z - Random.Range (120, 150));
		AudioManager.instance.Play ("evilLaugh");
		_speed = afterFirstChaseSpeed;
		follow = true;
	}
}
