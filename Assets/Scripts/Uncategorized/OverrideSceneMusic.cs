using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OverrideSceneMusic : MonoBehaviour {

	//public string newMusicName;
	// Use this for initialization
	void Start () 
	{
		string sceneName = SceneManager.GetActiveScene ().name;
		if (sceneName == "bossLevel")
			AudioManager.instance.PlayMusic ("bossLevel");
		else if (sceneName == "ChaseLevel")
			AudioManager.instance.PlayMusic ("chaseLevel");
		else
			AudioManager.instance.PlayMusic ("standardLevel");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
