using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour 
{
	public static AudioManager instance = null;

	public GameObject soundObjectPrefab = null;
	public int poolSize = 10;
	public bool willGrow = true;
	List<GameObject> soundObjectPool;

	public List<AudioClip> clipList;
	private Dictionary<string, AudioClip> clips;

	public List<AudioMixerGroup> mixerGroupList;
	private Dictionary<string, AudioMixerGroup> mixerGroups;

	public List<AudioMixerSnapshot> snapshotList;
	private Dictionary<string, AudioMixerSnapshot> snapshots;

	void Awake ()
	{
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () 
	{
		soundObjectPool = new List<GameObject> ();
		for (int i = 0; i < poolSize; i++) 
		{
			GameObject obj = (GameObject)Instantiate (soundObjectPrefab);
			obj.SetActive (false);
			soundObjectPool.Add (obj);
		}

		clips = new Dictionary<string, AudioClip> ();
		foreach (AudioClip clip in clipList)
			clips.Add (clip.name, clip);

		mixerGroups = new Dictionary<string, AudioMixerGroup> ();
		foreach (AudioMixerGroup mixerGroup in mixerGroupList)
			mixerGroups.Add (mixerGroup.name, mixerGroup);

		snapshots = new Dictionary<string, AudioMixerSnapshot> ();
		foreach (AudioMixerSnapshot snapshot in snapshotList)
			snapshots.Add (snapshot.name, snapshot);
	}

	void Play(string audioEvent, GameObject go)
	{
		GameObject soundObject = null;

		for (int i = 0; i < soundObjectPool.Count; i++) 
		{
			if (!soundObjectPool [i].activeInHierarchy) 
			{
				soundObject = soundObjectPool [i];
				break;
			} 
			else
				continue;
		}

		if (soundObject == null && willGrow) 
		{
			GameObject obj = (GameObject)Instantiate (soundObjectPrefab);
			soundObjectPool.Add (obj);
			obj.SetActive (false);
			soundObject = obj;
		}
		else if (soundObject == null && !willGrow) 
		{
			print ("Unable to grow object pool!!!");
			return;
		}

		AudioSource source = soundObject.GetComponent<AudioSource> ();

		/*Sample audioEvent:
		if (audioEvent == "music") 
		{
			source.clip = clips ["bg_music"];
			source.outputAudioMixerGroup = mixerGroups ["MX"];
			soundObject.SetActive (true);
		}*/
	}
}
