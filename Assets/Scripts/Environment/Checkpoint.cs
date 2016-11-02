using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CheckpointData
{
    public Vector3 currentPos;
    public float currentStartFuel;

    public void setData(Vector3 pos, float fuel)
    {
        currentPos = pos;
        currentStartFuel = fuel;
    }
}

public class Checkpoint : MonoBehaviour {

    public float initialFuel;
    public bool isInitialCheckpoint;
    public UnityEvent onCheckpointEnter;

    public static CheckpointData currentData;

    bool _isActivated = false;
    

	// Use this for initialization
	void Start () {
	    
	}

    void Awake()
    {
        if(isInitialCheckpoint && currentData == null)
        {
            _isActivated = true;
            currentData = new CheckpointData();
            currentData.currentPos = this.transform.position;
            currentData.currentStartFuel = initialFuel;
        }
        EventManager.StartListening(EventManager.Events.GOAL_REACHED, OnReloadScene);
        this.GetComponent<MeshRenderer>().material.color = Color.red;
        //EventManager.StartListening(EventManager.Events., OnReloadScene);
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collider other)
    {
        if(_isActivated == false && other.tag == "Character")
        {
            _isActivated = true;
            currentData.setData(transform.position, initialFuel);

            
            this.GetComponent<MeshRenderer>().material.color = Color.green;
            onCheckpointEnter.Invoke();
        }
    }

    void OnReloadScene()
    {
        currentData = null;
    }
}
