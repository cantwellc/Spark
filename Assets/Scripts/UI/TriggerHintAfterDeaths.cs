using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class TriggerHintAfterDeaths : MonoBehaviour {
    private static int deathCount = 0;

    public int numDeaths;
    public int numDeathsToShow;

    void Start()
    {
        numDeaths = deathCount;
    }

    void OnEnable()
    {
        EventManager.StartListening(EventManager.Events.DEATH_COUNTDOWN, OnPlayerDeath);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }


    void OnDisable()
    {
        EventManager.StopListening(EventManager.Events.DEATH_COUNTDOWN, OnPlayerDeath);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }


    private void OnSceneFinishedLoading(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name != "bossLevel") deathCount = 0;
    }

    private void OnPlayerDeath()
    {
        deathCount++;
        Debug.Log(deathCount + " player deaths");
        if (deathCount == numDeathsToShow) EventManager.TriggerEvent(EventManager.Events.SHOW_BOSS_HINT);
    }
}
