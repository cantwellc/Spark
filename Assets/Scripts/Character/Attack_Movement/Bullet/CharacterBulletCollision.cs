using UnityEngine;
using System.Collections;

public class CharacterBulletCollision : MonoBehaviour 
{
    public GameObject plasmaExplosionPrefab;

	private float _damage;

	void OnCollisionEnter(Collision other)
	{
        if (other == null) return;
		if (other.gameObject.tag == "Enemy")
		{
            if(other.gameObject.GetComponent<Armor>() == null)
            {
                Health enemyHealth = other.gameObject.GetComponent<Health>();
                enemyHealth.TakeDamage(_damage);
                GameObject explosion = (GameObject)Instantiate(plasmaExplosionPrefab, transform.position, Quaternion.Euler(-90f, 0, 0));
                Destroy(explosion, 0.5f);
                Destroy(gameObject);
            }
            else
            {
                handleWithArmor(other.gameObject);
            }
		}
		else if (other.gameObject.tag != "Character" && other.gameObject.tag != "Wall") 
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
    }

	public void SetDamage(float amount)
	{
		_damage = amount;
	}

    void OnDestroy()
    {
    }
}
