using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour {

	
    public void onClick()
    {
        Time.timeScale = 1;

        Canvas parentCanvas = GetComponentInParent<Canvas>();

        parentCanvas.enabled = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
