using UnityEngine;
using System.Collections;

public class EnemyFlameBulletCollision : EnemyBulletCollision {

    void Awake()
    {
        if (Character.current == null) return;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other) return;
        if (other.gameObject.tag == "Character")
        {
            other.GetComponent<Health>().TakeDamage(_damage);
        }
        else if (other.gameObject.tag != "Enemy" && other.gameObject.tag != "Plane" && other.gameObject.tag != "Blackhole"
            && other.gameObject.tag != "ExtraCollider" && other.gameObject.tag != "CharacterBullet")
        {
            Destroy(gameObject);
        }
    }
    
}
