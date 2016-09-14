using UnityEngine;
using System.Collections;

public class CharacterBulletCollision : MonoBehaviour 
{
    public GameObject plasmaExplosionPrefab;

	private float _damage;

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Health enemyHealth = other.gameObject.GetComponent<Health> ();
			enemyHealth.TakeDamage (_damage);
            GameObject explosion = (GameObject)Instantiate(plasmaExplosionPrefab, transform.position, Quaternion.Euler(-90f, 0, 0));
            Destroy(explosion, 0.5f);
            Destroy (gameObject);
		}
		else if (other.gameObject.tag != "Character" && other.gameObject.tag != "Wall") 
		{

            GameObject explosion = (GameObject)Instantiate(plasmaExplosionPrefab, transform.position, Quaternion.Euler(-90f, 0, 0));
            Destroy(explosion, 0.5f);
            Destroy (gameObject);
		}
	}
	public void SetDamage(float amount)
	{
		_damage = amount;
	}

    void OnDestroy()
    {
    }
}
