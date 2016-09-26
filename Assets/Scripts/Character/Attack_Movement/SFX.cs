using UnityEngine;
using System.Collections;

public class SFX : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip sfx;

    public void PlaySound()
    {
		audioSource.PlayOneShot(sfx);
    }
	public void StopSound()
	{
		audioSource.Stop ();
	}
}
