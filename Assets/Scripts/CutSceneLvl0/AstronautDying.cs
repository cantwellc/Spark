using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AstronautDying : MonoBehaviour {

	public GameObject explosion ;
	public ParticleSystem dyingEffect;
	public GameObject [] doorsToRemove;
	public float screamSfxStart;
	public float explodeSfxStart;
	private AudioSource audioSource;
	public AudioClip[] audioClips;
	public bool characterAstronaut;
	public UnityEvent onTransformShape;

	// Use this for initialization
	void Start () 
	{
		dyingEffect.Play ();
		audioSource = GetComponent<AudioSource> ();
		Invoke ("screamSfx", screamSfxStart);
		Invoke ("explodeSfx", explodeSfxStart);

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void screamSfx()
	{
		audioSource.clip = audioClips [0];
		audioSource.Play ();
	}
	void explodeSfx()
	{
		Instantiate (explosion, transform.position, transform.rotation);
		AudioSource.PlayClipAtPoint (audioClips [1], Camera.main.transform.position, 1.0f);

		foreach (GameObject door in doorsToRemove)
		{
			door.gameObject.SetActive (false);
		}
		if (characterAstronaut)
		{
			 GameObject [] meshes = GameObject.FindGameObjectsWithTag ("MeshWithRenderer");
			foreach (GameObject astronautMesh in meshes)
			{
				astronautMesh.GetComponent<Renderer> ().enabled = false;
			}	
			onTransformShape.Invoke ();


		} 
		else
		{
			Destroy (gameObject);
		}

	}


}
