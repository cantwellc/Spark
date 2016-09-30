using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System;

public class MEventTrigger : MonoBehaviour {

    public UnityEvent triggerEnter;
    public UnityEvent triggerStay;
    public UnityEvent triggerExit;

    public List<string> validTargetTags;
    // Use this for initialization
    void Start() {

    }

    void OnTriggerEnter(Collider col)
    {
        if (validTargetTags == null) return;
        if (!validTargetTags.Contains(col.gameObject.tag)) return;
        triggerEnter.Invoke();
    }

    void OnTriggerStay(Collider col)
    {
        if (validTargetTags == null) return;
        if (!validTargetTags.Contains(col.gameObject.tag)) return;
        triggerStay.Invoke();
    }

    void OnTriggerExit(Collider col)
    {
        if (validTargetTags == null) return;
        if (!validTargetTags.Contains(col.gameObject.tag)) return;
        triggerExit.Invoke();
    }

}
