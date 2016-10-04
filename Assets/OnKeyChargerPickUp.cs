using UnityEngine;
using System.Collections;

public class OnKeyChargerPickUp : MonoBehaviour
{
	public float chargeAmount;
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
			GameObject keyRing = GameObject.FindWithTag ("Keyring");
			keyRing.GetComponent<KeyCharge> ().addCharge (chargeAmount);
            DestroyObject(this.gameObject);
        }
    }
}