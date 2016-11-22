using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour 
{

	public Text finishText;
	public string nextScene;

	private bool _finishCheck = false;


	void OnTriggerStay(Collider col)
	{
		if (col.tag == "Character" && !_finishCheck) 
		{
			_finishCheck = true;
			StartCoroutine(loadNextScene());

		}
	}
	void Update()
	{

	}

    bool getFinish()
    {
        return _finishCheck;
    }

    IEnumerator  loadNextScene()
    {
        EventManager.TriggerEvent(EventManager.Events.GOAL_REACHED);
        //GameManager.current.checkpoint = null;
        float fadeTime = GameObject.Find("GameManager").GetComponent<SceneFader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        MetricsManager.Reset();
        SceneManager.LoadScene(nextScene);
    }

}
