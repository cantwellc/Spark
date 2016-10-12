using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallTriggerOff : MonoBehaviour {

	public List <GameObject> crushingWalls;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Character")
		{
			foreach (GameObject crusingWall in crushingWalls)
			{
				Crush crush = crusingWall.GetComponent<Crush> ();
				crush.StopCrushing ();
			}
		}
	}
}
