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
        if (refSprite != null)
        {
            refSprite.SetActive(true);
            Invoke("SetInactive", 2.0f);
        }
    }
}
