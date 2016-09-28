using UnityEngine;
using System.Collections;
using System;

public class ObjectDeactivator : MonoBehaviour {
    public GameObject target;
    public float delay;

    public void Deactivate()
    {
        StartCoroutine(DeactivateAfterDelay());
    }

    private IEnumerator DeactivateAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        target.SetActive(false);
    }
}
