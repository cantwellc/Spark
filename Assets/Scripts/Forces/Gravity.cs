using UnityEngine;
using System.Collections;
using System;

public class Gravity : MonoBehaviour 
{
    public float strength;
    public GameObject character;

	// Update is called once per frame
	void Update () 
	{
        character.GetComponent<Rigidbody>().AddForce(CalcGravity());
	}

    private Vector3 CalcGravity()
    {
        Vector3 vec = character.transform.position - transform.position;
        float r2 = vec.sqrMagnitude;
        var norm = vec.normalized;
        return - norm * strength / r2;

    }
}
