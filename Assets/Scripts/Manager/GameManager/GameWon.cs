using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour 
{

	public Text finishText;
	public string nextScene;

	private bool _finishCheck = false;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Character") 
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
        float fadeTime = GameObject.Find("GameManager").GetComponent<SceneFader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(nextScene);
    }

}
