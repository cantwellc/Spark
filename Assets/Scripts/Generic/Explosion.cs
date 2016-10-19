using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Explosion : MonoBehaviour
{
    public float explosionRadius = 5;
    public float explosionDamage = 5;
    public float explosionPower = 5;
	public float explosionDamageToCharacter = 5;

    private IEnumerator Start()
    {
        // wait one frame because some explosions instantiate debris which should then
        // be pushed by physics force
        yield return null;
        
        float r = explosionRadius;
        var cols = Physics.OverlapSphere(transform.position, r);
		var tags = new List<String> ();
        var rigidbodies = new List<Rigidbody>();
        foreach (var col in cols)
        {
            if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
            {
				if (col.tag != "ExtraCollider")
				{
					tags.Add (col.gameObject.tag);
					rigidbodies.Add (col.attachedRigidbody);
				}
            }
        }
		for(int i = 0 ; i < rigidbodies.Count;i++)
        {
			Rigidbody rb = rigidbodies [i];
			rb.AddExplosionForce(explosionPower, transform.position, r, 1, ForceMode.Impulse);
            if(rb.GetComponent<Health>() != null)
            {
				
				if (tags [i] == "Character")
				{
					rb.GetComponent<Health> ().TakeDamage (explosionDamageToCharacter);
				} 
				else
				{
					rb.GetComponent<Health> ().TakeDamage (explosionDamage);
				}

            }
        }
    }
}
