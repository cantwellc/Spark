using UnityEngine;
using System.Collections;

public class AlternatingMovement : MonoBehaviour {

	public enum Direction
	{
		Right,
		Left
	}
	public float speed;
	public Direction direction; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Direction.Right == direction)
		{
			transform.position += transform.right * speed * Time.deltaTime;
		} 
		else
		{
			transform.position += transform.right * -1 * speed * Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Wall")
		{
			if (direction == Direction.Right)
			{
				direction = Direction.Left;
			} 
			else
			{
				direction = Direction.Right;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
	
	}
}
