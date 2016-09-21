using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text notificationText;
    public Text fuelCountText;
    public Character ship;

    private GameObject _inGameUI;
    private GameObject popupUI;
    private FuelReservoir _fuelReservoir;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start ()
    {
        notificationText.enabled = false;
        _fuelReservoir = ship.GetComponent<FuelReservoir>();
        _inGameUI = GameObject.Find("In Game UI");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(CheatModeMessage(ship.ToggleCheatCode()));
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            EnableRestartPopup();
        }
    }

    void FixedUpdate()
    {
		fuelCountText.text = "Fuel: " +_fuelReservoir.fuelCount + "/" + _fuelReservoir.maxFuelCount;
    }

    IEnumerator CheatModeMessage(bool CheatMode)
    {
        if (CheatMode)
        {
            notificationText.text = "Cheat Mode Enabled!";
        }
        else
        {
            notificationText.text = "Cheat Mode Disabled!";
        }
        notificationText.enabled = true;
        notificationText.color = Color.red;
        yield return new WaitForSeconds(1.2f);
        notificationText.enabled = false;
    }

    void EnableRestartPopup()
    {
        Time.timeScale = 0;
        if (popupUI == null)
        {
            popupUI = _inGameUI.transform.Find("popup UI").gameObject;
        }
        popupUI.SetActive(true);
    }

    public void RestartClick()
    {
        Time.timeScale = 1;

        popupUI.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CancelClick()
    {
        Time.timeScale = 1;
        popupUI.SetActive(false);
    }
}
