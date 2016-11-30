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

		if (sceneName == "Level6D" || sceneName == "Level7" || sceneName == "Level8D" || sceneName == "Level9D")
			AudioManager.instance.PlayMusic ("excitedLevel");
		else if (sceneName == "bossLevel")
			AudioManager.instance.PlayMusic ("bossLevel");
		else if (sceneName == "GameStory")
			AudioManager.instance.PlayMusic ("opening");
		else if (sceneName == "MainMenu" || sceneName == "Credits")
			AudioManager.instance.PlayMusic ("mainMenu");
		else if (sceneName == "Ending")
			AudioManager.instance.PlayMusic ("ending");
		else
			AudioManager.instance.PlayMusic ("standardLevel");
	}
}
