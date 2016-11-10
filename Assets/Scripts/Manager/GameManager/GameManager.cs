﻿using UnityEngine;
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

	private string _characterPrefabPath;
    public static GameManager current;
    public Transform characterBirthPoint;

    // private
	private GAME_STATES _game_state;
    private bool _isPaused = false;

    void Awake()
    {
		_characterPrefabPath = "CharacterOld/Character";
		//_characterPrefabPath = "Prefabs/Character/Character";
		DontDestroyOnLoad(this);
        current = this;

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        if (Character.current == null)
        {
            if (Checkpoint.currentData != null)
            {
				GameObject charPrefab = (GameObject)Resources.Load(_characterPrefabPath);
                GameObject character = Instantiate(charPrefab);
                Character.current = character.GetComponent<Character>();
                character.transform.position = Checkpoint.currentData.currentPos;
                character.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
				string sceneName = SceneManager.GetActiveScene ().name;
				
				character.GetComponent<FuelReservoir>().fuelCount = Checkpoint.currentData.currentStartFuel;


            }
        }
        print("loaded");
        
        if(MetricsManager.ShouldReset())
        {
            MetricsManager.Reset();
        }
    }

    // Use this for initialization
    void Start ()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
            _game_state = GAME_STATES.MAIN_MENU;
        else
            _game_state = GAME_STATES.PLAYING;
        current = this;
        SceneManager.sceneLoaded += newSceneLoaded;
    }

    void OnEnable()
    {
        EventManager.StartListening(EventManager.Events.MAIN_MENU_START, StartGame);
        EventManager.StartListening(EventManager.Events.PLAYER_DEAD, PlayerDead);
        EventManager.StartListening(EventManager.Events.RESUME_GAME, OnResume);
        EventManager.StartListening(EventManager.Events.R_KEY, OnResume);

        if (Character.current == null)
        {
            if (Checkpoint.currentData != null)
            {
				GameObject charPrefab = (GameObject)Resources.Load(_characterPrefabPath);
                GameObject character = Instantiate(charPrefab);
                Character.current = character.GetComponent<Character>();
                character.transform.position = Checkpoint.currentData.currentPos;
                character.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
                character.GetComponent<FuelReservoir>().fuelCount = Checkpoint.currentData.currentStartFuel;
            }
        }
    }

    void OnDisable()
    {
        EventManager.StopListening(EventManager.Events.MAIN_MENU_START, StartGame);
        EventManager.StopListening(EventManager.Events.PLAYER_DEAD, PlayerDead);
        EventManager.StopListening(EventManager.Events.RESUME_GAME, OnResume);
        EventManager.StopListening(EventManager.Events.R_KEY, OnResume);
    }

    // Update is called once per frame
    void Update()
    {
        if (GAME_STATES.PLAYING == _game_state && Character.current == null)
        {
            if (Checkpoint.currentData != null)
            {
				GameObject charPrefab = (GameObject)Resources.Load(_characterPrefabPath);
                GameObject character = Instantiate(charPrefab);
                Character.current = character.GetComponent<Character>();
                character.transform.position = Checkpoint.currentData.currentPos;
                character.GetComponent<FuelReservoir>().fuelCount = Checkpoint.currentData.currentStartFuel;
            }
        }
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
                    Checkpoint.currentData = null;
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

                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    EventManager.TriggerEvent(EventManager.Events.TAB_KEY_DOWN);
                }

                if (Input.GetKeyUp(KeyCode.Tab))
                {
                    EventManager.TriggerEvent(EventManager.Events.TAB_KEY_UP);
                }

                break;

            case GAME_STATES.PLAYER_DEAD:
                if (Input.GetKeyDown(KeyCode.R))
                {
                    EventManager.TriggerEvent(EventManager.Events.R_KEY);
                    StartGame();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                }
                break;

            case GAME_STATES.IN_GAME_MENU:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    EventManager.TriggerEvent(EventManager.Events.ESC_KEY);
                }

                break;

            case GAME_STATES.MAIN_MENU:

                Cursor.visible = true;
                if(Checkpoint.currentData != null)
                {
                    Checkpoint.currentData = null;
                }

                /*if(GameObject.Find("Character") != null)
                {
                    Destroy(GameObject.Find("Character"));
                }

                if(GameObject.Find("Character(Clone)") != null)
                {
                    Destroy(GameObject.Find("Character(Clone)"));
                }*/

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
        _isPaused = false;
    }

    void newSceneLoaded(Scene newScene, LoadSceneMode mode)
    {
        if(newScene.buildIndex == 0)
        {
            _game_state = GAME_STATES.MAIN_MENU;
        }
        else
        {
            _game_state = GAME_STATES.PLAYING;
        }
    }

}
