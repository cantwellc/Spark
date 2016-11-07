using UnityEngine;
using System.Collections;

public class SlamShutWallsController : MonoBehaviour {

	public float initialDelay;
	public float delayOfOpeningAfterSlamming;
	public float delayOfSlammingAfterOpening;

	public float slamShuttingSpeed;
	public float openingSpeed;
	public  GameObject wall1;
	public  GameObject wall2;

    public bool hasTrigger;


	void Awake () 
	{
        if(!hasTrigger)
		    StartSlamming ();
	}
	
	// Update is called once per frame



	public void StartSlamming()
	{
		Invoke ("EnableWalls", initialDelay);
	}

	public void EnableWalls()
	{
		wall1.GetComponent<WallSlamShut> ().enabled = true;
		wall2.GetComponent<WallSlamShut> ().enabled = true;
	}
}
