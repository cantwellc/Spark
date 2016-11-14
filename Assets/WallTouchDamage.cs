using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class WallTouchDamage : MonoBehaviour {


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void onCollisionStay(Collider other)
    {
        if(other.tag == "Character")
        {
            
        }
    }
}
