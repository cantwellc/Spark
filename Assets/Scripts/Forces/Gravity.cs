using UnityEngine;
using System.Collections.Generic;
using System;

public class Gravity : MonoBehaviour 
{
    public float strength = 6.25f;
    private IList<GameObject> gravitationalObjectList = new List<GameObject>();

	// Update is called once per frame
	void Update () 
	{
        foreach(var other in gravitationalObjectList)
        {
            other.GetComponent<Rigidbody>().AddForce(CalcGravity(other));
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Gravitational>() == null) return;
        gravitationalObjectList.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if ( !gravitationalObjectList.Contains(other.gameObject) ) return;
        gravitationalObjectList.Remove(other.gameObject);
    }


    private Vector3 CalcGravity(GameObject other)
    {
        Vector3 vec = other.transform.position - transform.position;
        float r2 = vec.sqrMagnitude;
        var norm = vec.normalized;
        float m1= GetComponent<Rigidbody>().mass;
        float m2 = other.GetComponent<Rigidbody>().mass;
        return -norm * strength * m1 * m2 / r2;
    }
}
