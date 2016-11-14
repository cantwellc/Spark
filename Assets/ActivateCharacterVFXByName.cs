using UnityEngine;
using System.Collections;

public class ActivateCharacterVFXByName : MonoBehaviour {

	public string VFXname;
	// Use this for initialization
	void OnTriggerEnter (Collider other) 
	{
		if (other.tag == "Character")
		{
			GameObject VFX = GameObject.Find(VFXname) as GameObject;
			VFX.GetComponent<VFX_Player> ().PlayEffect ();
		}
	
	}
}
