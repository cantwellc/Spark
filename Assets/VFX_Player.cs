using UnityEngine;
using System.Collections;

public class VFX_Player : MonoBehaviour {

	public ParticleSystem particleEffect;

	// Update is called once per frame
	public void PlayEffect()
	{
		particleEffect.Play ();
		AudioManager.instance.Play ("burstFire");
	}
}
