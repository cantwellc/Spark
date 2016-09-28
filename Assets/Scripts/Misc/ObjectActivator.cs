using UnityEngine;
using System.Collections;
using System;

public class ObjectActivator : MonoBehaviour {
    public GameObject target;
    public float delay;
	
    public void Activate()
    {
        StartCoroutine(ActivateAfterDelay());
    }

    private IEnumerator ActivateAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        target.SetActive(true);
    }
}
