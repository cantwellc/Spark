using UnityEngine;
using System.Collections;

public class SuckFuelOnCollision : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            other.GetComponent<Health>().TakeDamage(20);
        }
    }
}