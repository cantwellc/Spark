using UnityEngine;
using System.Collections;

public class PedestalAction : MonoBehaviour {

	public GameObject portal;
	public bool startAction;
	// Use this for initialization
	void Start () 
	{
		
	}

	void OnTriggerEnter()
	{
	
	}

	void OnTriggerStay(Collider other)
	{
		
		if (startAction)
		{
			SpawnPortal ();
			startAction = false;
		}

	}

	void SpawnPortal()
	{
		portal.SetActive (true);
	}
}

