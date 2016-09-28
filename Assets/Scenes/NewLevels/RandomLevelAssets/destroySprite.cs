using UnityEngine;
using System.Collections;

public class destroySprite : MonoBehaviour {

    public GameObject turret;

	// Update is called once per frame
	void Update () {
        if (!turret)
            gameObject.SetActive(false);
	}
}
