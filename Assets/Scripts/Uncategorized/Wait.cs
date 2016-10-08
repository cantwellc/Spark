using UnityEngine;
using System.Collections;

public class Wait : MonoBehaviour {

	public float seconds;
	// Use this for initialization
	void Start () 
	{

		Invoke ("AudioPlay", 0.2f);
		Invoke ("EnableChasing", seconds);

	}
	void AudioPlay()
	{
		AudioManager.instance.Play ("evilLaugh");

	}

	void EnableChasing()
	{
		GetComponent<ChasePlayer> ().enabled = true;
	}
}
