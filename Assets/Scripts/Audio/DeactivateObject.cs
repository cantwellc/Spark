using UnityEngine;
using System.Collections;

public class DeactivateObject : MonoBehaviour 
{
	private AudioSource source = null;

	public bool canDeactivate = true;

	void Start ()
	{
		//source = gameObject.GetComponent<AudioSource> ();
	}

	void OnEnable()
	{
		source = gameObject.GetComponent<AudioSource> ();
		if (source.loop != true) 
		{
			if (source.clip != null)
				Invoke ("Deactivate", source.clip.length + 10.0f);
			else
				Invoke ("Deactivate", 2.0f);
		}
	}

	void Deactivate ()
	{
		if (canDeactivate == true)
			gameObject.SetActive (false);
	}
}
