using UnityEngine;
using System.Collections;

public class TriggerOtherText : MonoBehaviour {

	public GameObject next;
	public float secondsAfterInitializing = 0.0f;

	// Use this for initialization
	void Start () 
	{
		Invoke ("Activate", secondsAfterInitializing);
	}
	
	void Activate()
	{
		if(next!=null)
		next.SetActive (true);
	}
}
