using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class OnAwakeEvent : MonoBehaviour {
    public UnityEvent OnAwake;
	void Awake()
    {
        OnAwake.Invoke();
    }
}
