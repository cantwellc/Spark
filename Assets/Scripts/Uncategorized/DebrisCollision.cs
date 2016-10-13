using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class DebrisCollision : MonoBehaviour {

    Rigidbody _rbDebris;

    /*[System.Serializable]
    public class onTrigger : UnityEvent<float> { }
    public onTrigger collisionTrigger;*/

    void Start()
    {
        _rbDebris = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Character" || col.gameObject.tag == "Enemy")
        {
            Rigidbody _rbCharacter = col.gameObject.GetComponent<Rigidbody>();
            float damageTaken = (2 * _rbCharacter.mass * _rbCharacter.velocity.magnitude * _rbCharacter.velocity.magnitude / _rbDebris.mass);
            //collisionTrigger.Invoke(damageTaken);
            col.gameObject.GetComponent<Health>().TakeDamage(10*_rbDebris.mass);
            //Since debris is smaller than us we take smaller damage than debris
        }

    }
}
