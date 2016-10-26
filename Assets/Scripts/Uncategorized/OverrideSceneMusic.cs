using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OverrideSceneMusic : MonoBehaviour {

	//public string newMusicName;
	// Use this for initialization
	void Start () 
	{
		string sceneName = SceneManager.GetActiveScene ().name;
		if (sceneName== "bossLevel")
			AudioManager.instance.Play ("bossLevel");
		else if (sceneName == "ChaseLevel")
			AudioManager.instance.Play ("chaseLevel");
		else
			AudioManager.instance.Play ("standardLevel");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
