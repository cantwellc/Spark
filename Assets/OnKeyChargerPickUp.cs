using UnityEngine;
using System.Collections;

public class OnKeyChargerPickUp : MonoBehaviour
{
    public Character character; 
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
            character.keyChargersPickedUp += 1;
            DestroyObject(this.gameObject);
        }
    }
}