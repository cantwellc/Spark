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
	private float _mouseDissapearThreshold = 5.0f;
    private GAME_STATES _game_state;
	private Plane _mouseTargetPlane;


    void Awake()
    {
        //DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start ()
    {
		Cursor.visible = false;
		_mouseTargetPlane= new Plane(transform.up, character.transform.position);
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

	/// <summary>
	/// We find the mouseInWorldPosition where it intersects with the plane the player is on. Then we are only interested in the XZ plane because y is always 1
	/// Then we get the XZ plane components of character and we find distance between mouseWorldPositionXZ and CharacterPosition XZ in 2D , if this distance is smaller than our treshold
	/// that means the mouse is too closer to the character so to keep the distance we do the following:
	/// We use origin as character's xz coordinates and then find a point on them with radius = treshold+0.2 ( so a little bir farther) and thats it we put the crosshair there.
	/// There is a small gotcha that our character even if he does not have a rotation value, his barrel is rotated at 90 degrees so we are adding that to the character's Euler Angle.
	/// </summary>
	void OnGUI()
	{

		_crosshairRect = new Rect (Input.mousePosition.x - 10, Screen.height - Input.mousePosition.y - 10, 20, 20);
		Vector3 mouseInWorldPosition = GetTarget ();
		Vector2 mouseInXZWorld = new Vector2 (mouseInWorldPosition.x, mouseInWorldPosition.z);
		Vector2 characterInXZWorld = new Vector2 (character.transform.position.x, character.transform.position.z);
		if (Vector2.Distance (characterInXZWorld, mouseInXZWorld) > _mouseDissapearThreshold)
		{

			_crosshairRect = new Rect (Input.mousePosition.x - 10, Screen.height - Input.mousePosition.y -10, 20, 20);
		} 

		else
		{

			float cx = character.transform.position.x;
			float cz = character.transform.position.z;
			float r = _mouseDissapearThreshold + 0.2f;
			float eulerAngleY = character.transform.rotation.eulerAngles.y +90;
			float angleInDegrees =  (eulerAngleY > 180.0f) ? eulerAngleY - 360.0f : eulerAngleY;
			float a = angleInDegrees * Mathf.Deg2Rad;

			Vector3 crossHairWorld = new Vector3(cx - r * Mathf.Cos (a),1.0f, cz + r * Mathf.Sin (a));
			Vector2 newCrosshairPosition = Camera.main.WorldToScreenPoint (crossHairWorld);
			_crosshairRect = new Rect (newCrosshairPosition.x - 10, Screen.height - newCrosshairPosition.y -10, 20, 20);
		}
		GUI.DrawTexture (_crosshairRect,crosshairTexture);
	}

	public Vector3 GetTarget() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float rayDistance;
		var worldPosition = new GameObject ();
		if (_mouseTargetPlane.Raycast(ray, out rayDistance))
			worldPosition.transform.position = ray.GetPoint(rayDistance);
		return worldPosition.transform.position;
	}

}
