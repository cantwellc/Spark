using UnityEngine;
using System.Collections;

public class VisualEffect : MonoBehaviour {

	public ParticleSystem effectPrefab;
	private ParticleSystem _effect;
	public void ShowEffects()
	{
		if (!_effect)
		{
			_effect = Instantiate (effectPrefab, transform.position, transform.rotation) as ParticleSystem;
		}

	}
	public void StopEffects()
	{
		_effect.Stop ();
	}
}
