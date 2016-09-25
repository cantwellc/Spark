using UnityEngine;
using System.Collections;

public class ChargeSFX : MonoBehaviour {
    public AudioClip chargingSFX;
    public AudioSource audioSource;

    void HandleChargeStart()
    {
        AudioSource.PlayClipAtPoint(chargingSFX, Camera.main.transform.position, 1.0f);
    }

    void HandleChargeComplete()
    {

    }

}
