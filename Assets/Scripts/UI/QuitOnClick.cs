﻿
using System.Collections;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
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
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        float fadeTime = GameObject.Find("GameManager").GetComponent<SceneFader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
    }

    IEnumerator ApplicationQuit()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        float fadeTime = GameObject.Find("GameManager").GetComponent<SceneFader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.Quit();
    }

}
