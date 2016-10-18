using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class SpawnKey : MonoBehaviour {
    public UnityEvent OnSpawnKey;
    public UnityEvent OnSpawnKeyFailed;

    public GameObject key;
    public bool keyCollected;

	void OnEnable()
    {
        EventManager.StartListening(EventManager.Events.CHARACTER_ENTERED_KEY_PEDESTAL_TRIGGER, Spawn);
        EventManager.StartListening(EventManager.Events.KEY_COLLECTED, KeyCollected);
    }

    private void KeyCollected()
    {
        keyCollected = true;
    }

    private void Spawn()
    {
        if (!keyCollected) OnSpawnKeyFailed.Invoke();
        else {
            key.SetActive(true);
            OnSpawnKey.Invoke();
        }
    }
}
