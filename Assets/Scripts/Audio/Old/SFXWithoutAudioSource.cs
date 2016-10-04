using UnityEngine;
using System.Collections;

public class SFXWithoutAudioSource : MonoBehaviour 
{
	public enum SFXEvent
	{
		CharacterTakeDamage,
		OpenPortal
	}
	public SFXEvent sfxEvent;

	public void Play()
	{
		Debug.Log ("Playing Sound");
		if (sfxEvent == SFXEvent.CharacterTakeDamage)
		{
			AudioManager.instance.Play ("takeDamage");
		}
		if (sfxEvent == SFXEvent.OpenPortal)
		{
			AudioManager.instance.Play ("openPortal");
		}
	}
}
