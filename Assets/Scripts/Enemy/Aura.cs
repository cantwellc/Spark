using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Aura : MonoBehaviour {

    public enum AuraType
    {
        Damage,
        Slow
    }

    public AuraType auraType;
    public float dragRate;
    public float damagePerSecond;

    Dictionary<string, float> effectTime;
    
    

    // Use this for initialization
    void Start () {
	    
	}

    IEnumerator SlowDownObject(GameObject obj)
    {
        yield return new WaitForFixedUpdate();

        obj.GetComponent<SlowDownPhysics>().SlowDown(dragRate);

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

    // Update is called once per frame
    void Update () {
	
	}
}
