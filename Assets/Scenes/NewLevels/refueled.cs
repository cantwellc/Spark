using UnityEngine;
using System.Collections;

public class refueled : MonoBehaviour {

    public GameObject refSprite;

    void SetInactive()
    {
        refSprite.SetActive(false);
    }

	void OnTriggerEnter()
    {
        refSprite.SetActive(true);
        Invoke("SetInactive",2.0f);
    }
}
