using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ContinueScript : MonoBehaviour {

	public void LoadLastLevel()
	{
		if (!PlayerPrefs.HasKey ("LastLevel"))
		{
			//Make the btn not clickable
		} 
		else
		{
			string sceneName  = PlayerPrefs.GetString ("LastLevel");
			StartCoroutine(LoadScene(sceneName));
		}

	}

	IEnumerator LoadScene(string sceneName)
	{
		float fadeTime = GameObject.Find("GameManager").GetComponent<SceneFader>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene(sceneName);
	}

	public void StartPlay()
	{
		EventManager.TriggerEvent(EventManager.Events.MAIN_MENU_START);
	}
}
