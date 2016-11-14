using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Health : MonoBehaviour 
{
	
	public UnityEvent onDeath;
	public UnityEvent onTakeDamage;


    [SerializeField]
    private float _maxHealth;
	private bool _alive = true;
	public float MaxHealth
    {
        get
        {
            return _maxHealth;
        }
    }
	public float HealthPercent
    {
        get
        {
            return _currentHealth / MaxHealth;
        }
    }

    [SerializeField]



	private float _currentHealth;



    //Reduce the Ammount from health of the gameobject
    public virtual void TakeDamage(float amount)
    {
		_currentHealth -= amount;
		onTakeDamage.Invoke();

		if (_currentHealth <= 0 && _alive)
        {
            Dead();
        }
	}

	void Dead()
	{
		onDeath.Invoke ();
		gameObject.SetActive (false);
		_alive = false;
		Destroy (gameObject,2.0f);
	}

	public void PlaySound (string audioEvent)
	{
		AudioManager.instance.Play (audioEvent, gameObject);
	}

}
