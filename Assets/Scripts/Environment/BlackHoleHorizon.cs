using UnityEngine;
using System.Collections;

public class BlackHoleHorizon : MonoBehaviour {
    public Rigidbody blackHoleRigidBody;

	void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag != "Blackhole" && other.tag !="Plane" && other.tag != "CharacterBullet" && other.tag != "Obstacle")
        {
            var rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb == null)
                return;
            // Add mass and destroy other object
            var otherMass = rb.mass;
            blackHoleRigidBody.mass += otherMass;
            if (other.gameObject.tag == "Character") {
                other.gameObject.SendMessage("DestroyedByBlackHole");
            }
            else 
            { //Maybe adding things later
                other.gameObject.SendMessage("DestroyedByBlackHole");
            }
			//other.gameObject.SetActive (false);
		}
    }
}
