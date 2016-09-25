using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{


	public float maxHealth;
	public bool removeFromSceneWhenDead;
	public GameObject hitParticleEffect;
	public GameObject enemyDeadEffect;
	public float destroyHitEffectInSeconds;
	public float destroyDeadEffectInSeconds;

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
        //Add a sleep to add some satisfaction when hitting
        System.Threading.Thread.Sleep(20);
        if(rendererOfObject != null)
        {
            rendererOfObject.material.color = Color.red;
            Invoke("returnToOriginalColor", 0.1f);
        }
		GameObject enemyHitEffect = Instantiate (hitParticleEffect, transform.position, transform.rotation) as GameObject;
		Destroy (enemyHitEffect, destroyHitEffectInSeconds);
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
		GameObject deadEffect = Instantiate (enemyDeadEffect, transform.position, transform.rotation) as GameObject;
		Destroy (deadEffect,destroyDeadEffectInSeconds);
		if (removeFromSceneWhenDead)
		{
			Destroy (gameObject);
		}
	}




}
