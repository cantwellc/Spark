using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallTriggerOn : MonoBehaviour {

	public List <GameObject> crushingWalls;
	// Use this for initialization

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Character")
		{
			foreach (GameObject crusingWall in crushingWalls)
			{
				Crush crush = crusingWall.GetComponent<Crush> ();
				crush.StartCrushing ();
			}
		}
	}
}
