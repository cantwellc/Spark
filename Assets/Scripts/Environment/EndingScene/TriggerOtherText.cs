using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TriggerOtherText : MonoBehaviour {

	public GameObject next;
	public float secondsAfterInitializing = 0.0f;
	public bool changeScene = false;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (AudioDelay ());
		Invoke ("Activate", secondsAfterInitializing);
	}
	
	void Activate()
	{
		if(next!=null)
		next.SetActive (true);
		if (changeScene)
			StartCoroutine (loadNextScene());
	}

	IEnumerator  loadNextScene()
	{
		yield return new WaitForSeconds(0.0f);
		SceneManager.LoadScene("Credits");
	}

	IEnumerator  AudioDelay()
	{
		yield return new WaitForSeconds(0.5f);
		AudioManager.instance.Play (gameObject.name);
	}
}
