using UnityEngine;
using System.Collections;

public class BlackHoleHorizon : MonoBehaviour {
    public Rigidbody blackHoleRigidBody;

	void OnTriggerEnter(Collider other)
    {
        // Add mass and destroy other object
        var otherMass = other.gameObject.GetComponent<Rigidbody>().mass;
        blackHoleRigidBody.mass += otherMass;
        other.gameObject.SetActive(false);
    }
}
