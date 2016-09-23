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
    public Character character;



    // private
	private GAME_STATES _game_state;


    void Awake()
    {
        //DontDestroyOnLoad(this);
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

            EventManager.TriggerEvent(EventManager.Events.CHEAT_MODE);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //EnableRestartPopup();
            
        }
		if (Input.GetKeyDown(KeyCode.L))
		{
			Cursor.visible = true;
			SceneManager.LoadScene ("LevelSelectScene");

		}

        if(character.gameObject.activeSelf == false)
        {
            // Debug.Log("Player has died!");
            //DeadNotification();
            EventManager.TriggerEvent(EventManager.Events.PLAYER_DEAD);
        }
    }



}
