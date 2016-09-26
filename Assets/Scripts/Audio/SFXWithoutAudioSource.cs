using UnityEngine;
using System.Collections;

public class SFXWithoutAudioSource : MonoBehaviour 
{
	public AudioClip sfx;
	public float volume;
	public void PlaySoundWithoutSource()
	{
		
		AudioSource.PlayClipAtPoint(sfx,Camera.main.transform.position,volume);
	}
}
