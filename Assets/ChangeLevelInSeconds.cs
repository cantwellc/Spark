using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeLevelInSeconds : MonoBehaviour {

	// Use this for initialization
	public float loadInSeconds=7.0f;
	public string nextScene;
	void OnTriggerEnter (Collider col) 
	{
		if (col.tag == "Character")
		{
			sceneChangeInitialize ();
		}
	}
	
	IEnumerator  loadNextScene()
	{
		EventManager.TriggerEvent(EventManager.Events.GOAL_REACHED);
		float fadeTime = GameObject.Find("GameManager").GetComponent<SceneFader>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		MetricsManager.Reset();
		SceneManager.LoadScene(nextScene);
	}

	void sceneChangeInitialize()
	{
		Invoke ("changeScene", loadInSeconds);
	}

	void changeScene()
	{
		StartCoroutine (loadNextScene ());
	}





}
