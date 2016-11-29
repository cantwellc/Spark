using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ShowBossHint : MonoBehaviour {
    public GameObject bossHintPanel;
    public float showTime;

	void OnEnable()
    {
        EventManager.StartListening(EventManager.Events.SHOW_BOSS_HINT, ShowHint);
    }

    void OnDisable()
    {
        EventManager.StopListening(EventManager.Events.SHOW_BOSS_HINT, ShowHint);
    }

    private void ShowHint()
    {
        StartCoroutine(CoShowHint());
    }

    private IEnumerator CoShowHint()
    {
        bossHintPanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(showTime);
        bossHintPanel.gameObject.SetActive(false);
    }
}
