using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text notificationText;
    public Text fuelCountText;
    public Character ship;
    public GameObject popupUI;

    private FuelReservoir _fuelReservoir;

    // Use this for initialization
    void Start ()
    {
        notificationText.enabled = false;
        _fuelReservoir = ship.GetComponent<FuelReservoir>();
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
            enablePopup();
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

    void enablePopup()
    {
        Time.timeScale = 0;
        popupUI.SetActive(true);
    }

    public void RetartClick()
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
