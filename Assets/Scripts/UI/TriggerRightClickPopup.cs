using UnityEngine;
using System.Collections;

public class TriggerRightClickPopup : MonoBehaviour {

	void OnTriggerEnter()
    {
        EventManager.TriggerEvent(EventManager.Events.SHOW_RIGHT_CLICK_POPUP);
    }
}
