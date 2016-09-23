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

	public Texture2D crosshairTexture;

	private Rect _crosshairRect;

    // private
	private int _mouseDissapearThreshold = 90;
    private GAME_STATES _game_state;


    void Awake()
    {
        //DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start ()
    {
		Cursor.visible = false;
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
		//crosshairDrawing ();

        if(character.gameObject.activeSelf == false)
        {
            // Debug.Log("Player has died!");
            //DeadNotification();
            EventManager.TriggerEvent(EventManager.Events.PLAYER_DEAD);
        }
    }

	void OnGUI()
	{
		_crosshairRect =  new Rect (Input.mousePosition.x-10,Screen.height- Input.mousePosition.y -10, 20, 20);
		Vector3 characterScreenPos = Camera.main.WorldToScreenPoint (character.transform.position);
		Vector2 characterScreenPos2D = new Vector2 (characterScreenPos.x, characterScreenPos.y);
		Vector2 mousePosition2D = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);

		if (Vector2.Distance (characterScreenPos2D, mousePosition2D) > _mouseDissapearThreshold)
		{
			
			_crosshairRect = new Rect (Input.mousePosition.x - 10, Screen.height - Input.mousePosition.y -10, 20, 20);
		} 
		//This means the crosshair is too close to the character
		//We found a point in the circle with origin cx, An eulerAngleY which is Rotation of the ship+90 , because our model is 90 degrees in the unit circle
		else
		{
			float cx = characterScreenPos2D.x;
			float cy = characterScreenPos2D.y;
			float r = _mouseDissapearThreshold + 1;
			float eulerAngleY = character.transform.rotation.eulerAngles.y +90;
			float angleInDegrees =  (eulerAngleY > 180.0f) ? eulerAngleY - 360.0f : eulerAngleY;

			float a = angleInDegrees * Mathf.Deg2Rad;
			Vector2 newCrosshairPosition = new Vector2 (cx - r * Mathf.Cos (a), cy + r * Mathf.Sin (a));
			_crosshairRect = new Rect (newCrosshairPosition.x - 10, Screen.height - newCrosshairPosition.y -10, 20, 20);
		}
		GUI.DrawTexture (_crosshairRect,crosshairTexture);
	}

}
