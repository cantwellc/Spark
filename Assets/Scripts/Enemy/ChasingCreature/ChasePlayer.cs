using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour {

	public float speed;
	private Vector3 _targetPosition;
	private bool follow = true;
	void Start () 
	{

	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (follow)
		{
			float step = speed * Time.deltaTime;
			_targetPosition = new Vector3 (Character.current.transform.position.x - 1.0f, transform.position.y, Character.current.transform.position.z);
			transform.position = Vector3.MoveTowards (transform.position, _targetPosition, step);
			if (VeryCloseOnXZ())
			{
				GetComponent<AreaAttack> ().Attack ();
				follow = false;
			}
		}
		else
		{
			transform.position = new Vector3 (transform.position.x - Random.Range (20, 50), transform.position.y, transform.position.z - Random.Range (20, 50));
			follow = true;
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
}
