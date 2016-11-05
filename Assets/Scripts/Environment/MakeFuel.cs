using UnityEngine;
using System.Collections;

public class MakeFuel : MonoBehaviour {

    GameObject _fuelInstance;
    public GameObject fuel;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MakeOneFuel()
    {
        _fuelInstance = Instantiate(fuel, transform.position, transform.rotation) as GameObject;
        _fuelInstance.GetComponent<Fuel>().fuelAmmount = Random.Range(250, 350);
    }
}
