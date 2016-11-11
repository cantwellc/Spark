using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PressurePad : MonoBehaviour {

    bool pressured;

    public UnityEvent onPress;
    public UnityEvent onExit;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Character") return;
		AudioManager.instance.Play ("pressButton");
		GetComponent<MeshRenderer>().material.color = Color.green;
        onPress.Invoke();
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag != "Character") return;
        GetComponent<MeshRenderer>().material.color = Color.white;
        onExit.Invoke();
    }
}
