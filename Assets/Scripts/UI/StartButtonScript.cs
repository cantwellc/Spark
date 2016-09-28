using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartButtonScript : MonoBehaviour {

    public void LoadByIndex(int sceneIndex)
    {
        StartCoroutine(LoadScene(sceneIndex));
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        float fadeTime = GameObject.Find("GameManager").GetComponent<SceneFader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(sceneIndex);
    }

    public void StartPlay()
    {
        EventManager.TriggerEvent(EventManager.Events.MAIN_MENU_START);
    }

}
