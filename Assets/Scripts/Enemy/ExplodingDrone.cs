using UnityEngine;
using System.Collections;

public class ExplodingDrone : MonoBehaviour {

    public float moveForce;
    public float explosionRadius;
    public float explosionDamage;
    public float explosionPower;

    Rigidbody _rigidBody;
    bool exploded = false;
	// Use this for initialization
	void Start () {
        _rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Character.current == null) return;
        Transform targetTransform = Character.current.transform;

        Vector3 dir = (targetTransform.position - transform.position).normalized;
        _rigidBody.AddForce(dir * moveForce);

        Quaternion dest = Quaternion.LookRotation(dir.normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, dest, 1);
    }
    
    void Explode()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            if (hit.gameObject.tag != "Character" && hit.tag != "Enemy") continue;
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                //rb.AddExplosionForce(explosionPower, explosionPos, explosionRadius, 1f, ForceMode.Impulse);
                if (hit.GetComponent<Health>())
                {
                    hit.gameObject.GetComponent<Health>().TakeDamage(explosionDamage);
                }
            }
        }
    }

    void OnCollisionEnter()
    {
        if (exploded) return;
        exploded = true;
        Explode();
        GetComponent<Health>().TakeDamage(50f);
    }

    void OnCollisionStay()
    {
        if (exploded) return;
        exploded = true;
        Explode();
        GetComponent<Health>().TakeDamage(50f);
    }
}
