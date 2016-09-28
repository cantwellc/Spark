using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class MEvent : MonoBehaviour {
    public UnityEvent onTrigger;
    // Use this for initialization
    void Start () {
	
	}
	
    public void TriggerEvent()
    {
        onTrigger.Invoke();
    }
}
