using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class OnStartEvent : MonoBehaviour {
    public UnityEvent OnStart;
	// Use this for initialization
	void Start () {
        OnStart.Invoke();
	}
	
}
