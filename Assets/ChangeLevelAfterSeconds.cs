using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeLevelAfterSeconds : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Invoke ("runCoroutine",32.0f);
	}
	
	IEnumerator LoadScene()
	{
		float fadeTime = GameObject.Find("GameManager").GetComponent<SceneFader>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene("MainMenu");
	}
	void runCoroutine()
	{
		StartCoroutine(LoadScene());
	}

}
