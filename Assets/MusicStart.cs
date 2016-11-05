using UnityEngine;
using System.Collections;

public class MusicStart : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		AudioManager.instance.Play ("standardLevel");
	}
}
