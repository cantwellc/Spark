using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OverrideSceneMusic : MonoBehaviour {

	//public string newMusicName;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine ("Delay", 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Delay (float delayTime)
	{
		string sceneName = SceneManager.GetActiveScene ().name;

		yield return new WaitForSeconds (delayTime);

		if (sceneName == "Level1" || sceneName == "Level2" || sceneName == "Level3" || sceneName == "Level4" || sceneName == "Level5")
			AudioManager.instance.PlayMusic ("standardLevel");
		else if (sceneName == "bossLevel")
			AudioManager.instance.PlayMusic ("bossLevel");
		else if (sceneName == "GameStory")
			AudioManager.instance.PlayMusic ("opening");
		else if (sceneName == "MainMenu")
			AudioManager.instance.PlayMusic ("mainMenu");
		else
			AudioManager.instance.PlayMusic ("excitedLevel");
	}
}
