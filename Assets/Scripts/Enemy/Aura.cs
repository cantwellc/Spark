using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Aura : MonoBehaviour {

	private float _totalDrag;
	private float _baseDrag;

	public enum AuraType
    {
        Damage,
        Slow
    }

    public AuraType auraType;
    public float dragRate;
	public float maxDragRate;

    public float damagePerSecond;
	public bool enableIncrementingDrag;


    Dictionary<string, float> effectTime;
    
    

    // Use this for initialization
    void Start () 
	{
		_baseDrag = 0;
	}

    IEnumerator SlowDownObject(GameObject obj)
    {
        yield return new WaitForFixedUpdate();


		obj.GetComponent<SlowDownPhysics>().SlowDown(_totalDrag);

    }

    void OnTriggerEnter(Collider other)
    {
        if(AuraType.Slow == auraType)
        {
            if (other.gameObject.GetComponent<SlowDownPhysics>() != null)
            {
                StartCoroutine("SlowDownObject", other.gameObject);
            }
        }
        else
        {
            if (other.gameObject.GetComponent<Health>() != null)
            {
                other.gameObject.GetComponent<Health>().TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
		
        
		if (AuraType.Slow == auraType)
        {


			if (other.gameObject.GetComponent<SlowDownPhysics>() != null)
            {
                StartCoroutine("SlowDownObject", other.gameObject);
            }
        }
        else
        {
            if (other.gameObject.GetComponent<Health>() != null)
            {
                other.gameObject.GetComponent<Health>().TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }
    }

	void OnTriggerExit(Collider other)
	{
		if (enableIncrementingDrag)
		{
			
			if (other.gameObject.GetComponent<SlowDownPhysics>()!=null)
			{
				_baseDrag = 0;
			}
		}
	}

    // Update is called once per frame
    void Update () {
		if (enableIncrementingDrag)
		{
			_baseDrag += Time.deltaTime * dragRate;
			_totalDrag = _baseDrag + dragRate;

		}

		if (_totalDrag > maxDragRate)
		{
			_totalDrag = maxDragRate;
		}
	
	}
}
