using UnityEngine;
using System.Collections;

public class TriggerRightClickPopup : MonoBehaviour {

	public void TriggerEvent()
    {
        EventManager.TriggerEvent(EventManager.Events.SHOW_RIGHT_CLICK_POPUP);
    }
}
