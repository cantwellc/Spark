using UnityEngine;
using System.Collections;

public class OnKeyChargerPickUp : MonoBehaviour
{
	public float chargeAmount;
    // Use this for initialization
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
			GameObject keyRing = GameObject.FindWithTag ("Keyring");
			keyRing.GetComponent<KeyCharge> ().addCharge (chargeAmount);
            DestroyObject(this.gameObject);
        }
    }
	public void SetChargeAmount(float amount)
	{
		chargeAmount = amount;
	}
}