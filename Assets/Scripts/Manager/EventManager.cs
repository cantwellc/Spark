using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

    public enum Events
    {
        UPDATE_FUEL,
        CHEAT_MODE,
    }

    private Dictionary<Events, UnityEvent> _eventDictionary;

    private static EventManager _eventManager;

    public static EventManager instance
    {
        get
        {
            if (!_eventManager)
            {
                _eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!_eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    _eventManager.Init();
                }
            }

            return _eventManager;
        }
    }

    void Init()
    {
        if (_eventDictionary == null)
        {
            _eventDictionary = new Dictionary<Events, UnityEvent>();
        }
    }


    public static void StartListening(Events eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (instance._eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance._eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(Events eventName, UnityAction listener)
    {
        if (_eventManager == null) return;
        UnityEvent thisEvent = null;
        if (instance._eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(Events eventName)
    {
        UnityEvent thisEvent = null;
        if (instance._eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }

}
