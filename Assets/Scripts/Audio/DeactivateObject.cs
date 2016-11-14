using UnityEngine;
using System.Collections;

public class DeactivateObject : MonoBehaviour 
{
	private AudioSource source = null;

	public bool canDeactivate = true;

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
			StartCoroutine ("Fade");
		else
			return;
	}

	IEnumerator Fade ()
	{
		source = gameObject.GetComponent<AudioSource> ();
		while (source.volume > 0.0f)
		{
			source.volume -= Time.deltaTime / 1.0f;
		}
		gameObject.SetActive (false);
		yield return null;
	}
}
