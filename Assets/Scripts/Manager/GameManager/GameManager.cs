using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public enum GAME_STATES
{
    MAIN_MENU,
    IN_GAME_MENU,
    PLAYING,
    PLAYER_DEAD,

}

public class GameManager : MonoBehaviour {

    // public

    public static GameManager current;
    public Transform characterBirthPoint;


    // private
	private GAME_STATES _game_state;
    private bool _isPaused = false;

    void Awake()
    {
        DontDestroyOnLoad(this);
        current = this;

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        print("loaded");
        if (Character.current == null)
        {
            if (Checkpoint.currentData != null)
            {
                GameObject charPrefab = (GameObject)Resources.Load("Prefabs/Character/Character");
                GameObject character = Instantiate(charPrefab);
                character.transform.position = Checkpoint.currentData.currentPos;
                character.GetComponent<FuelReservoir>().fuelCount = Checkpoint.currentData.currentStartFuel;
            }
        }
    }

    // Use this for initialization
    void Start ()
    {
        _game_state = GAME_STATES.MAIN_MENU;
        current = this;
    }

    void OnEnable()
    {
        EventManager.StartListening(EventManager.Events.MAIN_MENU_START, StartGame);
        EventManager.StartListening(EventManager.Events.PLAYER_DEAD, PlayerDead);
        EventManager.StartListening(EventManager.Events.RESUME_GAME, OnResume);
    }

    void Ondisable()
    {
        EventManager.StopListening(EventManager.Events.MAIN_MENU_START, StartGame);
        EventManager.StopListening(EventManager.Events.PLAYER_DEAD, PlayerDead);
        EventManager.StopListening(EventManager.Events.RESUME_GAME, OnResume);
    }

    void OnLevelWasLoaded()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
		switch (_game_state)
        {

            case GAME_STATES.PLAYING:

                if (Input.GetKeyDown(KeyCode.B))
                {

                    EventManager.TriggerEvent(EventManager.Events.B_KEY);

                }

                if (Input.GetKeyDown(KeyCode.R))
                {

                    EventManager.TriggerEvent(EventManager.Events.R_KEY);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                }
                if (Input.GetKeyDown(KeyCode.L))
                {

					Cursor.visible = true;
                    SceneManager.LoadScene("LevelSelectScene");
				}

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (!_isPaused)
                    {
                        //Time.timeScale = 0;
                        _game_state = GAME_STATES.IN_GAME_MENU;
                        EventManager.TriggerEvent(EventManager.Events.ESC_KEY);
                        EventManager.TriggerEvent(EventManager.Events.PAUSE_GAME);
                        _isPaused = !_isPaused;
                    }
                }

                break;

            case GAME_STATES.PLAYER_DEAD:
                if (Input.GetKeyDown(KeyCode.R))
                {
                    EventManager.TriggerEvent(EventManager.Events.R_KEY);
					AudioManager.instance.DisableDeadCountDownSound ();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                }
                break;

            case GAME_STATES.IN_GAME_MENU:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    EventManager.TriggerEvent(EventManager.Events.ESC_KEY);
                }

                break;
        }
    }

    void StartGame()
    {
        _game_state = GAME_STATES.PLAYING;
    }

    void PlayerDead()
    {
        _game_state = GAME_STATES.PLAYER_DEAD;
    }

    void OnResume()
    {
        _game_state = GAME_STATES.PLAYING;
        Time.timeScale = 1;
        _isPaused = false;
    }

}
