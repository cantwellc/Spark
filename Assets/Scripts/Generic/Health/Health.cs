using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Health : MonoBehaviour 
{
    public UnityEvent OnTakeDamage;

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

    void Start()
    {
        OnTakeDamage = new UnityEvent();
    }

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
  //      if(enemyDeadEffect)
  //      {
  //          GameObject deadEffect = Instantiate(enemyDeadEffect, transform.position, transform.rotation) as GameObject;
  //          Destroy(deadEffect, destroyDeadEffectInSeconds);
  //      }
		//if (removeFromSceneWhenDead)
		//{
		//	Destroy (gameObject);
		//}
	}




}
