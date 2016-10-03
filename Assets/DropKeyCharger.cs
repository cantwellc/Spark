using UnityEngine;
using System.Collections;

public class DropKeyCharger : MonoBehaviour {

    public GameObject keyCharger;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void DropKeyChargerEvent()
    {

        Instantiate(keyCharger,transform.position,transform.rotation);
    }
}
