using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OverrideSceneMusic : MonoBehaviour {

	//public string newMusicName;
	// Use this for initialization
	void Start () 
	{
		if (SceneManager.GetActiveScene ().name == "bossLevel")
			AudioManager.instance.Play ("bossLevel");
		else
			AudioManager.instance.Play ("standardLevel");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
