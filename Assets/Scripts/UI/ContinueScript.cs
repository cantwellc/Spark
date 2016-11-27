using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ContinueScript : MonoBehaviour {

	public void LoadLastLevel()
	{
		
		if (PlayerPrefs.HasKey ("LastLevel"))
		{
			string sceneName  = PlayerPrefs.GetString ("LastLevel");
			StartCoroutine(LoadScene(sceneName));
		} 


	}

	void Start()
	{
		//PlayerPrefs.DeleteAll ();
		if (!PlayerPrefs.HasKey ("LastLevel"))
		{
			gameObject.SetActive (false);
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
