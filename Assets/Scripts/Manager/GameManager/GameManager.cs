using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Text notificationText;
    public Text fuelCountText;
    public Character ship;

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
            StartCoroutine(CheatModeMassage(ship.ToggleCheatCode()));
        }
    }

    void FixedUpdate()
    {
        fuelCountText.text = _fuelReservoir.fuelCount + "/" + _fuelReservoir.maxFuelCount;
    }

    IEnumerator CheatModeMassage(bool CheatMode)
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
}
