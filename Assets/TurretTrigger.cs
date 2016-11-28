using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretTrigger : MonoBehaviour {

    public List<GameObject> turrets;
	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Character")
        {
            Debug.Log("Testing");
            foreach (GameObject go in turrets)
            {
                go.GetComponent<Turret>()._startShooting = true;
            }
        }
    }
}
