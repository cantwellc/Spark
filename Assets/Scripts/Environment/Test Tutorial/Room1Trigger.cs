using UnityEngine;
using System.Collections;

public class Room1Trigger : MonoBehaviour {

    public GameObject responseObject;
    public GameObject firstCrashWall;

	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Character")
        {
            responseObject.SetActive(true);
            firstCrashWall.GetComponent<Crush>().StartCrushing();
        }
    }
}
