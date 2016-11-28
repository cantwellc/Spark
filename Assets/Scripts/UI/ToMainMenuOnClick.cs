using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToMainMenuOnClick : MonoBehaviour {

	public void MainMenuOnClick()
    {
        Cursor.visible = true;
        StartCoroutine(QuitToMainMenu());
    }

    IEnumerator QuitToMainMenu()
    {
        Time.timeScale = 1;
		GameObject gameManager = GameObject.Find ("GameManager") as GameObject;
		float fadeTime =gameManager.GetComponent<SceneFader>().BeginFade(1);
		gameManager.GetComponent<GameManager> ().UnPause ();


        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(0);
    }
}
