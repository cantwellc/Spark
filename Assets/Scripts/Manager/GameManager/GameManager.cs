using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public enum GAME_STATES
{
    MAIN_MENU,
    PLAYING,
    PLAYER_DEAD,

}

public class GameManager : MonoBehaviour {

    // public



    // private
	private GAME_STATES _game_state;


    void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
		
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            //StartCoroutine(CheatModeMessage(character.ToggleCheatCode()));

            EventManager.TriggerEvent(EventManager.Events.B_KEY);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            EventManager.TriggerEvent(EventManager.Events.R_KEY);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //EnableRestartPopup();
            
        }
		if (Input.GetKeyDown(KeyCode.L))
		{
			Cursor.visible = true;
			SceneManager.LoadScene ("LevelSelectScene");

		}

    }



}
