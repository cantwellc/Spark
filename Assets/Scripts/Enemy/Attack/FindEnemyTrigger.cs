using UnityEngine;
using System.Collections;

public class FindEnemyTrigger : MonoBehaviour {
    
    //Can simply change collider shape without changing script

	void Start () {
	
	}
	

	void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Character")
		    SendMessageUpwards("StartShooting");
    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Character")
            SendMessageUpwards("StartShooting");
    }


    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Character")
            SendMessageUpwards("StopShooting");
    }
}
