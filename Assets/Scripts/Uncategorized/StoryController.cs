using UnityEngine;
using System.Collections.Generic;

public class StoryController : MonoBehaviour {
    public StoryFrame firstFrame;

	// Use this for initialization
	void Start () 
	{
        firstFrame.StartFrame();
	}

	public void PlaySound (string audioEvent)
	{
		AudioManager.instance.Play (audioEvent);
	}
}
