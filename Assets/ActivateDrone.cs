using System;
using System.Collections;
using UnityEngine;

public class ActivateDrone : MonoBehaviour {
    public GameObject activeLight;
    public GameObject propulsionParticles;
    public float delay;
	
    public void Activate()
    {
        activeLight.SetActive(true);
        StartCoroutine(ActivateAfterDelay());
    }

    private IEnumerator ActivateAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        propulsionParticles.SetActive(true);
        GetComponent<ExplodingDrone>().enabled = true;
    }
}
