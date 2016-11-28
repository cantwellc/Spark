using UnityEngine;
using System.Collections;

public class DestroyCharacter : MonoBehaviour {

	private bool _destroyed = false;

	
	// Update is called once per frame
	void Update () 
	{
		GameObject character = GameObject.Find ("Character(Clone)") as GameObject;
		if (character != null)
		{
			_destroyed = true;
			character.SetActive (false);
		}

	}
}
