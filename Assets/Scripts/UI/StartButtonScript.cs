using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartButtonScript : MonoBehaviour {

    public void LoadByIndex(string sceneName)
    {
		StartCoroutine(LoadScene(sceneName));
    }

	IEnumerator LoadScene(string sceneName)
    {
		PlayerPrefs.DeleteKey ("LastLevel");
		float fadeTime = GameObject.Find("GameManager").GetComponent<SceneFader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene(sceneName);
    }

    public void StartPlay()
    {
        EventManager.TriggerEvent(EventManager.Events.MAIN_MENU_START);
    }

}
