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
        float fadeTime = GameObject.Find("GameManager").GetComponent<SceneFader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(0);
    }
}
