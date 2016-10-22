using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallTriggerActivateAll : MonoBehaviour {

	public List <GameObject> crushingWalls;
	// Use this for initialization

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Character")
		{
			foreach (GameObject crusingWall in crushingWalls)
			{
				MoveForward [] crushWallsComponents = crusingWall.GetComponentsInChildren<MoveForward> ();
				foreach (MoveForward crushWallComponent in crushWallsComponents)
				{
					crushWallComponent.StartMoving ();
				}
			}
		}
	}
}
