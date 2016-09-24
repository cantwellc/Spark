using UnityEngine;
using System.Collections;

public class FindEnemyTrigger : MonoBehaviour {
    
    //Can simply change collider shape without changing script

	void Start () {
	
	}
	

	void OnTriggerEnter(Collider coll)
    {
        SendMessageUpwards("StartShooting");
    }

    void OnTriggerStay(Collider coll)
    {
        SendMessageUpwards("StartShooting");
    }


    void OnTriggerExit(Collider coll)
    {
        SendMessageUpwards("StopShooting");
    }
}
