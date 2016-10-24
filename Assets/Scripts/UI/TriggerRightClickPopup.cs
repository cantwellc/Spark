using UnityEngine;
using System.Collections;

public class TriggerRightClickPopup : MonoBehaviour {

	public void TriggerPopupEvent(bool on)
    {
        if (on) EventManager.TriggerEvent(EventManager.Events.SHOW_RIGHT_CLICK_POPUP);
        else EventManager.TriggerEvent(EventManager.Events.HIDE_RIGHT_CLICK_POPUP);
    }
}
