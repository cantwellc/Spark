using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class UIEventHandler : MonoBehaviour {

    private GameObject PopupWindow;
    private UnityAction R;

    void Awake()
    {
        PopupWindow = transform.Find("Canvas/Popup window").gameObject;
        R = new UnityAction(RKey);
    }

	// Use this for initialization
	void Start () {
        EventManager.StartListening("R Key Pressed", R);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void RKey()
    {
        Time.timeScale = 0;
        PopupWindow.SetActive(true);
    }

    public void RestartButton()
    {
        EventManager.TriggerEvent("Restart Button Pressed");
    }

    public void CancelButton()
    {
        EventManager.TriggerEvent("Cancel Button Pressed");
    }

}
