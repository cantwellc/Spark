using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartOnClick : MonoBehaviour {

	public void Restart()
    {
        Time.timeScale = 1;
        EventManager.TriggerEvent(EventManager.Events.R_KEY);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
