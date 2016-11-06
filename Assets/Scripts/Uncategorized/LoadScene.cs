using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class LoadScene : MonoBehaviour {
    public string sceneName;

     void OnEnable()
    {
        EventManager.StartListening(EventManager.Events.LOAD_NEXT_SCENE, OnLoadNextScene);
    }

    private void OnLoadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }

}
