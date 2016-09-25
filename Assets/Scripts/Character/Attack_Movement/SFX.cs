using UnityEngine;
using System.Collections;

public class SFX : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip plasmaSfx;

    public void PlaySound()
    {
        audioSource.PlayOneShot(plasmaSfx);
    }
}
