using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerDataPanelControl : MonoBehaviour {

    public Text fuelIndicator;
	public Text keyChargeIndicator;
    public Text levelIndicator;
    public GameObject playerDataPanel;


    private FuelReservoir _fuelReservior;
	private KeyCharge _keyCharge;
    private int _maxFuelAmt;
    private int _currentFuelAmt;

    void Awake()
    {
        SceneManager.sceneLoaded += newSceneLoaded;
    }

    // Use this for initialization
    void Start () {
        TryGetFuelReservior();
        if (_fuelReservior != null)
        {
            _maxFuelAmt = (int)_fuelReservior.maxFuelCount;
            _currentFuelAmt = (int)_fuelReservior.fuelCount;
        }

        fuelIndicator.text = "Fuel: " + _currentFuelAmt + "/" + _maxFuelAmt;

    }

    void OnEnable()
    {
        EventManager.StartListening(EventManager.Events.TAB_KEY_DOWN, EnableMySelf);
        EventManager.StartListening(EventManager.Events.TAB_KEY_UP, DisableMySelf);
    }
	
    void OnDisable()
    {
        EventManager.StopListening(EventManager.Events.TAB_KEY_DOWN, EnableMySelf);
        EventManager.StopListening(EventManager.Events.TAB_KEY_UP, DisableMySelf);
    }

	// Update is called once per frame
	void Update () {
		if (_fuelReservior != null)
		{
			_maxFuelAmt = (int)_fuelReservior.maxFuelCount;
			_currentFuelAmt = (int)_fuelReservior.fuelCount;
		} 
		else
		{
			TryGetFuelReservior ();
		}

        fuelIndicator.text = "Fuel: " + _currentFuelAmt + "/" + _maxFuelAmt;
		if (_keyCharge != null)
		{
			keyChargeIndicator.text = "Key Found : " + _keyCharge.GetChargeStatus ();
		} 
		else
		{
			TryGetFuelReservior ();
		}
    }

    void newSceneLoaded(Scene newScene, LoadSceneMode mode)
    {
        if (_fuelReservior == null)
        {
            TryGetFuelReservior();
        }
        if (levelIndicator != null)
        {
            levelIndicator.text = "Level: " + newScene.buildIndex;
        }
    }

    void TryGetFuelReservior()
    {
		GameObject Character = GameObject.FindGameObjectWithTag("Character");
      
        if (Character != null)
        {
            _fuelReservior = Character.GetComponent<FuelReservoir>();
			_keyCharge = GameObject.FindGameObjectWithTag ("Keyring").GetComponent<KeyCharge> ();
        }
    }

    void EnableMySelf()
    {
        playerDataPanel.SetActive(true);
    }

    void DisableMySelf()
    {
        playerDataPanel.SetActive(false);
    }
}
