using UnityEngine;
using System.Collections;
using System;

public class WormHole : MonoBehaviour 
{
    public WormHole exit;
    public GameObject character;
    public float Cooldown;

    private bool _triggerEnabled = true;

    public void OnTriggerEnter()
    {
        if (!_triggerEnabled) return;
        _triggerEnabled = false;
        StartCoroutine(EnableTriggerAfterCooldown());
        exit.TakeShip();
    }

    public void TakeShip()
    {
        _triggerEnabled = false;
        character.transform.position = transform.position;
        StartCoroutine(EnableTriggerAfterCooldown());
    }

    private IEnumerator EnableTriggerAfterCooldown()
    {
        yield return new WaitForSeconds(Cooldown);
        _triggerEnabled = true;
        yield break;
    }
}
