using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TurretCollision : MonoBehaviour
{

    Rigidbody _rbTurret;

    [System.Serializable]
    public class onTrigger : UnityEvent<float> { }
    public onTrigger collisionTrigger;

    void Start()
    {
        _rbTurret = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Character")
        {
            Rigidbody _rbCharacter = col.gameObject.GetComponent<Rigidbody>();
            float damageTaken = (2 * _rbCharacter.mass * _rbCharacter.velocity.magnitude * _rbCharacter.velocity.magnitude / _rbTurret.mass);
            collisionTrigger.Invoke(damageTaken);
        }

    }
}
