using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class QuitToMainMenu : MonoBehaviour 
{		
		public void Quit()
		{
			#if UNITY_EDITOR

			StartCoroutine(EditorQuit());

			#else
			StartCoroutine(ApplicationQuit());
			#endif
		}

		IEnumerator EditorQuit()
		{
			if(Time.timeScale == 0)
			{
				Time.timeScale = 1;
			}
			float fadeTime = GameObject.Find("GameManager").GetComponent<SceneFader>().BeginFade(1);
			yield return new WaitForSeconds (fadeTime);
			SceneManager.LoadScene ("MainMenu");
			
			
		}

		IEnumerator ApplicationQuit()
		{
			if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
			}
			float fadeTime = GameObject.Find("GameManager").GetComponent<SceneFader>().BeginFade(1);
			yield return new WaitForSeconds (fadeTime);
			SceneManager.LoadScene ("MainMenu");
		}

	
}
