using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    public bool isInitialCheckpoint;

    bool _isActivated = false;

	// Use this for initialization
	void Start () {
	    
	}

    void Awake()
    {
        if(isInitialCheckpoint)
        {

        }
    }
	
	// Update is called once per frame
	void Update () {
	    if(_isActivated)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            this.GetComponent<MeshRenderer>().material.color = Color.red;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        _isActivated = true;
    }
}
