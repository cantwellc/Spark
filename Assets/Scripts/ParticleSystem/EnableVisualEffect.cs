using UnityEngine;
using System.Collections;

public class EnableVisualEffect : MonoBehaviour {

	public ParticleSystem visualEffect;
	// Use this for initialization
	public void Play()
	{
		visualEffect.gameObject.SetActive (true);
		visualEffect.Play ();
	}
	public void Stop()
	{
		visualEffect.Stop ();
	}
}
