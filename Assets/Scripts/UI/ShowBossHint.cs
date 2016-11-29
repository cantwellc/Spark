using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ShowBossHint : MonoBehaviour {
    public GameObject bossHintPanel;
    public float showTime;
	public float transitionTime = 0.2f;


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
		
		int i = 0;
		bossHintPanel.gameObject.SetActive (true);
		GameObject image1 = (bossHintPanel.transform.Find ("Image1")).gameObject;
		GameObject image2 = (bossHintPanel.transform.Find ("Image2")).gameObject;
		image1.SetActive (false);
		while (i != 5)
		{
			image1.SetActive (true);
			yield return new WaitForSeconds (transitionTime);
			image1.SetActive (false);
			image2.SetActive (true);
			yield return new WaitForSeconds (transitionTime);
			image2.SetActive (false);
			i++;

		}
		bossHintPanel.gameObject.SetActive (false);
    }
}
