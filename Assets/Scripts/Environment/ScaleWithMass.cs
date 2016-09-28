using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ScaleWithMass : MonoBehaviour {

    private float baseMass;
    private float ratio;

    void Awake()
    {
        baseMass = GetComponent<Rigidbody>().mass;
        ratio = 1.0f;
    }

    void Update()
    {
        var mass = GetComponent<Rigidbody>().mass;
        ratio = mass / baseMass;
        transform.localScale = transform.localScale * ratio;
        baseMass = mass;
    }
	
}
