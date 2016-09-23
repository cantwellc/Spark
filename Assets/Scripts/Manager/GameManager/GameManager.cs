using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
	public Texture2D crosshairTexture;
	private Rect _crosshairRect;
	private int _mouseDissapearThreshold = 90;
    public Character character;

    //private GameObject _inGameUI;
    //private GameObject popupUI;

    // Actions
    //private UnityAction _restartButton;
    //private UnityAction _cancelButton;

    void Awake()
    {
        //DontDestroyOnLoad(this);
        
    }

    // Use this for initialization
    void Start ()
    {
       // _inGameUI = GameObject.Find("In Game UI");
		//Cursor.SetCursor (crosshairTexture,new Vector2(crosshairTexture.width/2,crosshairTexture.height/2),CursorMode.Auto);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            // StartCoroutine(CheatModeMessage(character.ToggleCheatCode()));

            EventManager.TriggerEvent(EventManager.Events.CHEAT_MODE);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //EnableRestartPopup();
            //EventManager.StartListening("Restart Button Pressed", _restartButton);
            //EventManager.StartListening("Cancel Button Pressed", _cancelButton);
            //EventManager.TriggerEvent("R Key Pressed");
        }
		//crosshairDrawing ();
    }




	void crosshairDrawing()
	{
		Vector3 characterScreenPos = Camera.main.WorldToScreenPoint (character.transform.position);
		
		//Check if the cursor is close
		if (Mathf.Abs(characterScreenPos.x - Input.mousePosition.x) < _mouseDissapearThreshold && Mathf.Abs(characterScreenPos.y - Input.mousePosition.y)<_mouseDissapearThreshold)
		{
			
			Cursor.visible = false;
		} 
		else
		{
			
			Cursor.visible = true;
			Cursor.SetCursor (crosshairTexture,new Vector2(crosshairTexture.width/2,crosshairTexture.height/2),CursorMode.Auto);

		}

	}



    void FixedUpdate()
    {
        //fuelCountText.text = "Fuel: " +_fuelReservoir.fuelCount + "/" + _fuelReservoir.maxFuelCount;

        //EventManager.TriggerEvent(EventManager.Events.UPDATE_FUEL);
    }

    //void EnableRestartPopup()
    //{
    //    Time.timeScale = 0;
    //    if (popupUI == null)
    //    {
    //        popupUI = _inGameUI.transform.Find("popup UI").gameObject;
    //    }
    //    popupUI.SetActive(true);
    //}

    //public void RestartClick()
    //{
    //    Time.timeScale = 1;

    //    popupUI.SetActive(false);

    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

    //public void CancelClick()
    //{
    //    Time.timeScale = 1;
    //    popupUI.SetActive(false);
    //}
}
