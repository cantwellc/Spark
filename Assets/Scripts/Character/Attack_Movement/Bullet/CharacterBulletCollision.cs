using UnityEngine;
using System.Collections;

public class CharacterBulletCollision : MonoBehaviour 
{
    public GameObject plasmaExplosionPrefab;

	private float _damage;

	void OnTriggerEnter(Collider other)
	{
        
		if (other == null) return;
		if (other.gameObject.tag == "Enemy")
		{
			
            if(other.gameObject.GetComponent<Armor>() == null)
            {
				if(other.gameObject.GetComponent<Health>() != null)
                {
                    Health enemyHealth = other.gameObject.GetComponent<Health>();
                    enemyHealth.TakeDamage(_damage);
                }
                GameObject explosion = (GameObject)Instantiate(plasmaExplosionPrefab, transform.position, Quaternion.Euler(-90f, 0, 0));
                Destroy(explosion, 0.5f);
                Destroy(gameObject);
            }
            else
            {
                handleWithArmor(other.gameObject);
            }
		}
		else if (other.gameObject.tag != "Character" &&  other.gameObject.tag!="ExtraCollider" && !(other.isTrigger && other.tag == "Untagged") && other.gameObject.tag!="CharacterBullet") 
		{

            GameObject explosion = (GameObject)Instantiate(plasmaExplosionPrefab, transform.position, Quaternion.Euler(-90f, 0, 0));
            Destroy(explosion, 0.5f);
            Destroy (gameObject);
		}
	}

    void handleWithArmor(GameObject other)
    {
        Armor.ArmorType armorType = other.GetComponent<Armor>().armorType;
        if (Armor.ArmorType.ImmuneToPlasma == armorType)
        {
            GameObject explosion = (GameObject)Instantiate(plasmaExplosionPrefab, transform.position, Quaternion.Euler(-90f, 0, 0));
			Destroy(explosion, 0.5f);
            Destroy(gameObject);
        }
        else if(Armor.ArmorType.DamageReduction == armorType)
        {
            Health enemyHealth = other.gameObject.GetComponent<Health>();
            enemyHealth.TakeDamage(_damage* other.GetComponent<Armor>().damageReduction);
            GameObject explosion = (GameObject)Instantiate(plasmaExplosionPrefab, transform.position, Quaternion.Euler(-90f, 0, 0));
            Destroy(explosion, 0.5f);
            Destroy(gameObject);
        }
        else if(Armor.ArmorType.AbsorbPlasma == armorType)
        {
            other.SendMessage("AbsorbPlasma");
            GameObject explosion = (GameObject)Instantiate(plasmaExplosionPrefab, transform.position, Quaternion.Euler(-90f, 0, 0));
            Destroy(explosion, 0.5f);
            Destroy(gameObject);
        }
        else if(Armor.ArmorType.Reflective == armorType)
        {
			AudioManager.instance.Play ("reflect", gameObject);
			Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.velocity = -0.3f *rigidbody.velocity;
            Destroy(gameObject, 0.2f);
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
