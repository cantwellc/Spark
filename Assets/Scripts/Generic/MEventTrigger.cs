using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class MEventTrigger : MonoBehaviour {

    public UnityEvent onTrigger;

    // Use this for initialization
    void Start() {

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Character")
        {
            onTrigger.Invoke();
        }
    }
}
