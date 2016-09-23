using UnityEngine;
using System.Collections;

public class dontDestroyUI : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

}
