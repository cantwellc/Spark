using UnityEngine;
using System.Collections;

public class DropKeyCharger : MonoBehaviour {

    public GameObject keyCharger;
    public GameObject fuelContainer;
	public float chargeAmount;
	public bool dropKey;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void DropKeyChargerEvent()
    {
		if (dropKey)
		{
			GameObject k = Instantiate (keyCharger, transform.position, transform.rotation) as GameObject;
			k.GetComponent<OnKeyChargerPickUp> ().SetChargeAmount (chargeAmount);
			dropKey = false;
		}
        else
        {
            GameObject k = Instantiate(fuelContainer, transform.position, transform.rotation) as GameObject;
            k.GetComponent<OnKeyChargerPickUp>().SetChargeAmount(chargeAmount);
            dropKey = false;
        }
    }
}
