using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelStackManager : MonoBehaviour {

    public GameObject ESC_Panel;
    public GameObject in_Game_Text;
    public GameObject Quit_Popup_panel;


    private static Stack<GameObject> _panelStack = new Stack<GameObject>(); 

	// Use this for initialization
	void OnEnable () {
        EventManager.StartListening(EventManager.Events.ESC_KEY, ESC_Click);
        EventManager.StartListening(EventManager.Events.R_KEY, OnRestart);
	}

    void OnDisable()
    {
        EventManager.StopListening(EventManager.Events.ESC_KEY, ESC_Click);
        EventManager.StopListening(EventManager.Events.R_KEY, OnRestart);
    }

    public void ESC_Click()
    {
        if(_panelStack.Count == 0)
        {
            ESC_Panel.SetActive(true);
            in_Game_Text.SetActive(false);
            _panelStack.Push(ESC_Panel);
        }
        else if(_panelStack.Count == 1)
        {
            GameObject currentPanel = _panelStack.Pop();
            currentPanel.SetActive(false);
            in_Game_Text.SetActive(true);
            EventManager.TriggerEvent(EventManager.Events.RESUME_GAME);
        }

        else
        {
            _panelStack.Pop().SetActive(false);
            _panelStack.Peek().SetActive(true);
        }

        waitOneFrame();

    }

    public void pushPanel(GameObject panel)
    {
        _panelStack.Peek().SetActive(false);
        panel.SetActive(true);
        _panelStack.Push(panel);
    }

    IEnumerator waitOneFrame()
    {
        yield return new WaitForEndOfFrame();
    }

    void OnRestart()
    {
        ESC_Panel.SetActive(false);
        in_Game_Text.SetActive(true);
    }

    public void ClearStack()
    {
        while(_panelStack.Count != 0)
        {
            _panelStack.Pop().SetActive(false);
        }
    }
}
