using UnityEngine;
using System.Collections;

public class TriggerEvent : MonoBehaviour {
    public EventManager.Events triggerEvent;

	public void Trigger()
    {
        EventManager.TriggerEvent(triggerEvent);
    }
}
