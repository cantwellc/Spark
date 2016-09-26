using UnityEngine;
using System.Collections;

public class SFXWithoutAudioSource : MonoBehaviour 
{
	public AudioClip sfx;
	public void PlaySoundWithoutSource()
	{
		AudioSource.PlayClipAtPoint(sfx,Camera.main.transform.position,1.5f);
	}
}
