using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnableCharacter : MonoBehaviour {

	// Use this for initialization
	public void Enable()
	{
		GameObject[] character = Resources.FindObjectsOfTypeAll<GameObject> ();
		foreach (GameObject gameObj in character)
		{
			if (gameObj.name == "Character")
			{
				gameObj.SetActive (true);

				StartCoroutine(loadNextScene());
				break;
			}
		}
	}
	IEnumerator  loadNextScene()
	{
		EventManager.TriggerEvent(EventManager.Events.GOAL_REACHED);
		float fadeTime = GameObject.Find("GameManager").GetComponent<SceneFader>().BeginFade(1);
		yield return new WaitForSeconds(1.0f);
		SceneManager.LoadScene("level1");
	}
}
