using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Health : MonoBehaviour 
{
	
	public UnityEvent OnTakeDamage;
	public UnityEvent OnDeath;

	public float maxHealth;
	public float HealthPercent
    {
        get
        {
            return _currentHealth / maxHealth;
        }
    }

    [SerializeField]



	private float _currentHealth;



    //Reduce the Ammount from health of the gameobject
    public void TakeDamage(float amount)
    {
		_currentHealth -= amount;

        OnTakeDamage.Invoke();

        if (_currentHealth <= 0)
        {
            Dead();
        }
	}

	void Dead()
	{
		OnDeath.Invoke ();
		gameObject.SetActive (false);
		Destroy (gameObject,2.0f);
	}

}
