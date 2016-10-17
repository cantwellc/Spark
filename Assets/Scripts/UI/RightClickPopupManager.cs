using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class RightClickPopupManager : MonoBehaviour {
    public GameObject RightClickPopupPanel;
	
    void OnEnable()
    {
        EventManager.StartListening(EventManager.Events.SHOW_RIGHT_CLICK_POPUP, OnShowRightClickPopup);
        EventManager.StartListening(EventManager.Events.HIDE_RIGHT_CLICK_POPUP, OnHideRightClickPopup);
    }

    private void OnHideRightClickPopup()
    {
        RightClickPopupPanel.SetActive(false);
    }

    private void OnShowRightClickPopup()
    {
        RightClickPopupPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
        if (!RightClickPopupPanel.activeInHierarchy) return;
        if (Input.GetMouseButtonDown(1)) EventManager.TriggerEvent(EventManager.Events.HIDE_RIGHT_CLICK_POPUP);
	}
}
