using UnityEngine;
using System.Collections;

public class activate : MonoBehaviour {

    public GameObject activateThis;

	void OnTriggerEnter(Collider Other)
    {
        if(Other.tag == "Character")
            activateThis.SetActive(true);
    }
}
