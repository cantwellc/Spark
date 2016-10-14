using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {

    public GameObject[] buttons;
    public GameObject activate;

    private int _numberOfButtons;
    private int _numberOfButtonPressed = 0;

	// Use this for initialization
	void Start () {
        _numberOfButtons = buttons.Length;
	}
	

    public void PressButton(ButtonPress button)
    {
        if (button.isPressed())
        {
            _numberOfButtonPressed++;
            Debug.Log(_numberOfButtonPressed);
        }
        else
        {
            _numberOfButtonPressed--;
            Debug.Log(_numberOfButtonPressed);
        }

        if(_numberOfButtonPressed == _numberOfButtons)
        {
            AllButtonsPressed();
        }
        
    }

    void AllButtonsPressed()
    {
        Debug.Log("all buttons are pressed!");
        activate.SetActive(false);
    }
}
