using UnityEngine;
using System.Collections;
using System;

public class Gravity : MonoBehaviour {
    public float Strength;
    public GameObject Ship;

	// Update is called once per frame
	void Update () {
        Ship.GetComponent<Rigidbody>().AddForce(CalcGravity());
	}

    private Vector3 CalcGravity()
    {
        Vector3 vec = Ship.transform.position - transform.position;
        float r2 = vec.sqrMagnitude;
        var norm = vec.normalized;
        return - norm * Strength / r2;

    }
}
