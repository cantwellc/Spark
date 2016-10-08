using UnityEngine;
using System.Collections;

public class OverrideSceneMusic : MonoBehaviour {

	public string newMusicName;
	// Use this for initialization
	void Start () 
	{
		GameObject audioManager = GameObject.Find ("AudioManager");
		audioManager.GetComponent<AudioManager> ().overrideBGMusic (newMusicName);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
