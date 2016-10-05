using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AsteroidCollision : MonoBehaviour {

    Rigidbody _rbAsteroid;

    [System.Serializable]
    public class onTrigger : UnityEvent<float> { }
    public onTrigger collisionTrigger;

    void Start()
    {
        _rbAsteroid = GetComponent<Rigidbody>();
    }

	void OnCollisionEnter(Collision col)
    {
      
        if (col.gameObject.tag == "Character")
        {
            Rigidbody _rbCharacter = col.gameObject.GetComponent<Rigidbody>();

			float damageTaken = (2*_rbCharacter.mass * _rbCharacter.velocity.magnitude * _rbCharacter.velocity.magnitude / _rbAsteroid.mass);
			Debug.Log ("Asteroid Damage " + damageTaken);
			collisionTrigger.Invoke(damageTaken);
        }

    }
}
