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
				Invoke ("Deactivate", source.clip.length + 2.0f);
			else
				Invoke ("Deactivate", 2.0f);
		}
	}

	public void Deactivate ()
	{
		if (canDeactivate == true && gameObject.activeInHierarchy == true)
			StartCoroutine ("Fade");
		else
			return;
	}

	IEnumerator Fade ()
	{
		source = gameObject.GetComponent<AudioSource> ();
		while (source.volume > 0.0f)
		{
			source.volume -= Time.deltaTime * 2.0f;
			yield return new WaitForSeconds (0.0001f);
		}
		gameObject.SetActive (false);
	}
}
