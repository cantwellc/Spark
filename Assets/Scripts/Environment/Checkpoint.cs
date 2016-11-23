using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CheckpointData
{
    public Vector3 currentPos;
	public Vector3 chaserPos;
    public float currentStartFuel;
    public bool hasKey;

    public void setData(Vector3 pos, float fuel)
    {
        currentPos = pos;
        currentStartFuel = fuel;
        hasKey = false;
    }

    
}

public class Checkpoint : MonoBehaviour {

    public float initialFuel;
    public bool isInitialCheckpoint;
    public UnityEvent onCheckpointEnter;
    public UnityEvent onCheckpointEnterOnSpawn;

    public static CheckpointData currentData;

    bool _isActivated = false;
    bool hasKey = false;

	// Use this for initialization
	void Start () {
	    
	}

    void Awake()
    {
		
		if (isInitialCheckpoint && currentData == null)
		{
			_isActivated = true;
			currentData = new CheckpointData ();
			currentData.setData (transform.position, initialFuel);
		} 

        EventManager.StartListening(EventManager.Events.GOAL_REACHED, OnReloadScene);
        EventManager.StartListening(EventManager.Events.KEY_COLLECTED, OnKeyCollected);
        hasKey = false;
        if (currentData != null && currentData.hasKey) hasKey = true;
        this.GetComponent<MeshRenderer>().material.color = Color.red;
        //EventManager.StartListening(EventManager.Events., OnReloadScene);
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collider other)
    {
		
		if(other.tag == "Character")
        {
			if(currentData != null && currentData.currentPos == transform.position)
            {
                print("spawn");
                //StartCoroutine(ExecuteAfterTime(0.05f));
                onCheckpointEnterOnSpawn.Invoke();
            }

			if (!isInitialCheckpoint && !_isActivated)
				AudioManager.instance.Play ("checkpoint");

			_isActivated = true;
            currentData.setData(transform.position, initialFuel);
            if (hasKey)
            {
                makeTheCheckPointGreen();
                currentData.hasKey = true;
				GameObject SecondaryCanvas = GameObject.Find ("LevelText");
				SecondaryCanvas.transform.Find ("CrystalAcquired").gameObject.SetActive (true);
            } else
            {
				makeTheCheckPointGreen();
				//makeTheCheckPointYellow();
            }
            onCheckpointEnter.Invoke();
            if(currentData.hasKey)
            {
                GetComponent<TriggerEvent>().Trigger();
            }

			/*foreach (Transform child in transform)
			{
				if (child.name == "ChaseSpawn")
				{
					currentData.chaserPos = child.position;
					Debug.Log ("Set chaserpos to " + currentData.chaserPos);
				}
			}*/
	
        }
    }
    

    public void setChaserPos(Transform pos)
    {
        currentData.chaserPos = pos.position;
        Debug.Log("Set chaserpos to " + currentData.chaserPos);
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        onCheckpointEnterOnSpawn.Invoke();
        // Code to execute after the delay
    }

    void OnKeyCollected()
    {
        hasKey = true;
    }

    void OnReloadScene()
    {
        currentData = null;
    }

	public void makeTheCheckPointGreen()
	{
		Transform[] children = this.GetComponentsInChildren<Transform> ();
		foreach (Transform child in children)
		{
			if (child.name == "Lights")
			{
				child.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
			}
		}
	}

    public void makeTheCheckPointYellow()
    {
        Transform[] children = this.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == "Lights")
            {
                child.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
            }
        }
    }
}
