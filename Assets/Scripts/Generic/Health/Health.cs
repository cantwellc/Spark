using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{


	public float maxHealth;
	public bool removeFromSceneWhenDead;
	public GameObject hitParticleEffect;
	public float destroyEffectInSeconds;

	public Renderer rendererOfObject;
	private Color _originalColor;

    public float HealthPercent
    {
        get
        {
            return _currentHealth / maxHealth;
        }
    }

    [SerializeField]
	private float _currentHealth;

	void Start () 
	{
		_currentHealth = maxHealth;
		_originalColor = rendererOfObject.material.color;
	}

	//Reduce the Ammount from health of the gameobject
	public void TakeDamage(float amount)
	{
		
		rendererOfObject.material.color = Color.red;
		GameObject enemyHitEffect = Instantiate (hitParticleEffect, transform.position, transform.rotation) as GameObject;
		Destroy (enemyHitEffect, destroyEffectInSeconds);
		Invoke ("returnToOriginalColor", 0.1f);
		_currentHealth -= amount;

		if (_currentHealth <= 0)
		{
			Dead ();
		}
	}

	void returnToOriginalColor()
	{
			rendererOfObject.material.color = _originalColor;
	}

	void Dead()
	{
		
		if (removeFromSceneWhenDead)
		{
			Destroy (gameObject);
		}
	}




}
