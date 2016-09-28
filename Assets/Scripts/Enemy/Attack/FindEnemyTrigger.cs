using UnityEngine;
using System.Collections;

public class FindEnemyTrigger : MonoBehaviour {


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
