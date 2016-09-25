using UnityEngine;
using System.Collections;

public class QuitOnClick : MonoBehaviour {

    public void Quit()
    {
#if UNITY_EDITOR
        StartCoroutine(EditorQuit());
#else
        StartCoroutine(ApplicationQuit());
#endif
    }

    IEnumerator EditorQuit()
    {
        float fadeTime = GameObject.Find("GameManager").GetComponent<SceneFader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        UnityEditor.EditorApplication.isPlaying = false;
    }

    IEnumerator ApplicationQuit()
    {
        float fadeTime = GameObject.Find("GameManager").GetComponent<SceneFader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.Quit();
    }

}
