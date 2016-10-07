using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Class to handle crush between two colliders
/// This component should be placed on a pair of objects
/// with trigger colliders.  It will maintain a list of colliders
/// currently triggering this, and check to see if the same object 
/// is also triggering the paired collider.  If the object in question
/// is triggering both this collider and the paired collider,
/// this component will apply maxHealth damage to the triggering
/// object's health.
/// </summary>
public class DualTriggerDamageCollider : MonoBehaviour {
    public DualTriggerDamageCollider pairedCollider;
    public float damage;
    public List<Collider> triggeringColliders;

	void OnTriggerEnter(Collider other)
    {
        triggeringColliders.Add(other);
    }

    void OnTriggerStay(Collider other)
    {
        if (!triggeringColliders.Contains(other)) triggeringColliders.Add(other);
        if (pairedCollider.triggeringColliders.Contains(other))
        {
            var health = other.GetComponent<Health>();
            if (health == null) return;
            health.TakeDamage(damage);
        }
    }

    void OnTriggerExit(Collider other)
    {
        triggeringColliders.Remove(other);
    }
}
