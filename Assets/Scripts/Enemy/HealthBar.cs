using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
    public Health health;

    void Update()
    {
        //GetComponent<Renderer>().material.SetFloat("_Cutoff", health.HealthPercent);
    }
}
