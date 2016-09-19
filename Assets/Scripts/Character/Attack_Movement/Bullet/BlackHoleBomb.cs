using UnityEngine;
using System.Collections;
using System;

public class BlackHoleBomb : MonoBehaviour {

    public GameObject Projectile;
    public GameObject BlackHole;

    public Vector3 target;
    public float threshold;
    public float flightTime;

    private float _startTime;

    void OnEnable()
    {
        _startTime = Time.time;
    }

    void Update()
    {
        var distance = (transform.position - target).magnitude;
        if (distance < threshold) Collapse();
        if ((Time.time - _startTime) >= flightTime) Collapse();
    }

    private void Collapse()
    {
        transform.position = target;
        Projectile.SetActive(false);
        BlackHole.SetActive(true);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
