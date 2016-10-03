using UnityEngine;
using System.Collections;

public class DropKeyCharger : MonoBehaviour {

    public GameObject keyCharger;
	public bool dropKey;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void DropKeyChargerEvent()
    {
		if (dropKey)
		{
			Instantiate (keyCharger, transform.position, transform.rotation);
		}
    }
}
