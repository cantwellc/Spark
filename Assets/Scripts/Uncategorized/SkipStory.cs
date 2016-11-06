using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SkipStory : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (!Input.anyKey) return;
        // TODO kill audio
        EventManager.TriggerEvent(EventManager.Events.LOAD_NEXT_SCENE);
    }
}
