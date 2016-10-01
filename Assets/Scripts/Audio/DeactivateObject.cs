using UnityEngine;
using System.Collections;

public class DeactivateObject : MonoBehaviour 
{
	private AudioSource source = null;

	void Start ()
	{
		source = gameObject.GetComponent<AudioSource> ();
	}

	void OnEnable()
	{
		if (source != null)
			Invoke ("Deactivate", source.clip.length);
		else
			Invoke ("Deactivate", 0.0f);
	}

	void Deactivate ()
	{
		gameObject.SetActive(false);
	}
}
