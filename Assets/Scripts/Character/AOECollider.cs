using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System;
using System.Collections;

public class AOECollider : MonoBehaviour {
    public UnityEvent OnStartAOE;
    public UnityEvent OnStopAOE;

    public List<string> validTargetTags;
    public float damagePerSecond;

    private bool _doingDamage;
    private List<Health> _currentTargetHealthList = new List<Health>();
    private float _lastDamageTime;

	void OnTriggerEnter(Collider other)
    {
        if (validTargetTags == null) return;
        if (!validTargetTags.Contains(other.tag)) return;
        var health = other.gameObject.GetComponent<Health>();
        if (health != null) _currentTargetHealthList.Add(health);
    }

    void OnTriggerExit(Collider other)
    {
        if (validTargetTags == null) return;
        if (!validTargetTags.Contains(other.tag)) return;
        _currentTargetHealthList.Remove(other.gameObject.GetComponent<Health>());
    }

    /// <summary>
    /// Start AOE.  Optional duration.
    /// </summary>
    public void StartAOE(float duration = -1.0f)
    {
        _doingDamage = true;
        _lastDamageTime = Time.time;
        if(duration != -1.0f) StartCoroutine(StopAfterDuration(duration));
        OnStartAOE.Invoke();
    }

    private IEnumerator StopAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        StopAOE();
    }

    public void StopAOE()
    {
        _doingDamage = false;
        OnStopAOE.Invoke();
    }

    void Update()
    {
        if (!_doingDamage) return;
        float time = Time.time - _lastDamageTime;
        float damage = time * damagePerSecond;
        foreach(var health in _currentTargetHealthList)
        {
            health.TakeDamage(damage);
        }
        _lastDamageTime = Time.time;
    }
}
