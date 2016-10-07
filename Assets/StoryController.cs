using UnityEngine;
using System.Collections.Generic;

public class StoryController : MonoBehaviour {
    public List<StoryFrame> frames;

	// Use this for initialization
	void Start () {
        frames[0].StartFrame();
	}

}
