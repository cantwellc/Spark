using UnityEngine;
using System.Collections;

public class activateSprite : MonoBehaviour {

    public GameObject sprite;

	void OnTriggerEnter(Collider Other)
    {
        if(Other.tag == "Character")
            sprite.SetActive(true);
    }
}
