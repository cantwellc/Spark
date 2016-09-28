using UnityEngine;
using System.Collections;

public class ExplodingDrone : MonoBehaviour {

    public float moveForce;

    private Rigidbody _rigidBody;
    private bool _exploded = false;
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
    
   /* void Explode()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            if (hit.gameObject.tag != "Character" && hit.tag != "Enemy") continue;
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(explosionPower, explosionPos, explosionRadius, 1f, ForceMode.Impulse);
                if (hit.GetComponent<Health>())
                {
                    hit.gameObject.GetComponent<Health>().TakeDamage(explosionDamage);
                }
            }
        }
    }*/

    void OnCollisionEnter(Collision collision)
    {
		
		if (collision.gameObject.name.Contains("Door")|| collision.gameObject.name.Contains("Drone")) return;
		if (_exploded) return;
        _exploded = true;
        //Explode();
        GetComponent<Health>().TakeDamage(50f);
    }

    void OnCollisionStay(Collision collision)
    {
		if (collision.gameObject.name.Contains("Door")|| collision.gameObject.name.Contains("Drone")) return;
        if (_exploded) return;
        _exploded = true;
       // Explode(); 
        GetComponent<Health>().TakeDamage(50f);
    }
}
