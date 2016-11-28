using UnityEngine;
using System.Collections;

public class StopAllSound : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		GameObject.Find ("AudioManager").GetComponent<AudioManager> ().DisableAllSounds ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
