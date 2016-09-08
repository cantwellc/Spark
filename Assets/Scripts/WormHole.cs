using UnityEngine;
using System.Collections;
using System;

public class WormHole : MonoBehaviour {
    public WormHole Exit;
    public GameObject Ship;
    public float Cooldown;

    bool _triggerEnabled = true;

    public void OnTriggerEnter()
    {
        if (!_triggerEnabled) return;
        _triggerEnabled = false;
        StartCoroutine(EnableTriggerAfterCooldown());
        Exit.TakeShip();
    }

    public void TakeShip()
    {
        _triggerEnabled = false;
        Ship.transform.position = transform.position;
        StartCoroutine(EnableTriggerAfterCooldown());
    }

    private IEnumerator EnableTriggerAfterCooldown()
    {
        yield return new WaitForSeconds(Cooldown);
        _triggerEnabled = true;
        yield break;
    }
}
