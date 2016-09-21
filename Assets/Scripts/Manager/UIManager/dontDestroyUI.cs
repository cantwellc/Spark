using UnityEngine;
using System.Collections;

public class dontDestroyUI : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(this);
	}

}
