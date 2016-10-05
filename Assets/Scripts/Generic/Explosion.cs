using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Explosion : MonoBehaviour
{
    public float explosionRadius = 5;
    public float explosionDamage = 5 ;
    public float explosionPower = 5;

    private IEnumerator Start()
    {
        // wait one frame because some explosions instantiate debris which should then
        // be pushed by physics force
        yield return null;
        
        float r = explosionRadius;
        var cols = Physics.OverlapSphere(transform.position, r);
        var rigidbodies = new List<Rigidbody>();
        foreach (var col in cols)
        {
            if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
            {
				rigidbodies.Add(col.attachedRigidbody);
            }
        }
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.AddExplosionForce(explosionPower, transform.position, r, 1, ForceMode.Impulse);
            if(rb.GetComponent<Health>() != null)
            {
                rb.GetComponent<Health>().TakeDamage(explosionDamage);
            }
        }
    }
}
