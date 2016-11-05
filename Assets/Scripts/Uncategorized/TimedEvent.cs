using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class TimedEvent : MonoBehaviour {
    public UnityEvent OnTimerStart;
    public UnityEvent OnTimerFinish;

    public float timer;
    
    public void StartTimer()
    {
        StartCoroutine(Timer(timer));
    }

    private IEnumerator Timer(float time)
    {
        OnTimerStart.Invoke();
        yield return new WaitForSeconds(time);
        OnTimerFinish.Invoke();
    }
}
