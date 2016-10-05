﻿using UnityEngine;
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

	private bool canAlarm = true;

	private GameObject alarm;

	void Awake ()
	{
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}

	void Start () 
	{
		soundObjectPool = new List<GameObject> ();
		for (int i = 0; i < poolSize; i++) 
		{
			GameObject obj = (GameObject)Instantiate (soundObjectPrefab);
			obj.transform.parent = gameObject.transform;
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

	public void Play(string audioEvent)
	{
		if (audioEvent == "stopDeathCountdown") 
		{
			if (alarm != null) 
			{
				alarm.GetComponent<AudioSource> ().loop = false;
				alarm.SetActive (false);
				return;
			}
		}

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
			obj.transform.parent = gameObject.transform;
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
		if (source.volume != 1.0f)
			source.volume = 1.0f;

		if (audioEvent == "plasmaFire") 
		{
			source.volume = 0.3f;
			source.clip = clips ["laser_raw3"];
			source.outputAudioMixerGroup = mixerGroups ["PrimaryFire"];
			soundObject.SetActive (true);
		}

		if (audioEvent == "burstCharge") 
		{
			snapshots ["SFXDefault"].TransitionTo (0.0f);
			source.clip = clips ["chargeUp_raw4"];
			source.outputAudioMixerGroup = mixerGroups ["SecondaryCharge"];
			soundObject.SetActive (true);
		}

		if (audioEvent == "burstFire") 
		{
			snapshots ["ChargeOff"].TransitionTo (0.5f);
			source.clip = clips ["plasmaBurst_raw1"];
			source.outputAudioMixerGroup = mixerGroups ["SecondaryFire"];
			soundObject.SetActive (true);
		}

		if (audioEvent == "cantFire") 
		{
			source.clip = clips ["attackFail_raw1"];
			source.outputAudioMixerGroup = mixerGroups ["PrimaryFire"];
			soundObject.SetActive (true);
		}

		if (audioEvent == "lowFuel") 
		{
			if (canAlarm) 
			{
				canAlarm = false;
				source.clip = clips ["lowFuel_raw1"];
				source.outputAudioMixerGroup = mixerGroups ["Alarm"];
				soundObject.SetActive (true);
				StartCoroutine (Wait (audioEvent, source.clip.length));
			}
		}

		if (audioEvent == "refuel") 
		{
			source.clip = clips ["refuel_raw1"];
			source.outputAudioMixerGroup = mixerGroups ["Refuel"];
			soundObject.SetActive (true);
		}

		if (audioEvent == "deathCountdown") 
		{
			source.clip = clips ["Alert_Low_On_Fuel"];
			source.outputAudioMixerGroup = mixerGroups ["Alarm"];
			source.loop = true;
			soundObject.GetComponent<DeactivateObject> ().canDeactivate = false;
			soundObject.SetActive (true);
			alarm = soundObject;
		}

		if (audioEvent == "death") 
		{
			source.clip = clips ["explosion_raw6"];
			source.outputAudioMixerGroup = mixerGroups ["Explosions"];
			Play ("stopDeathCountdown");
			soundObject.SetActive (true);
		}
		//Added
		if (audioEvent == "takeDamage")
		{
			source.volume = 0.2f;
			source.clip = clips ["take_damage_4"];
			source.outputAudioMixerGroup = mixerGroups ["SFX"];
			soundObject.SetActive (true);
		}
		if (audioEvent == "openPortal")
		{
			
			source.clip = clips ["portal_sound"];
			source.outputAudioMixerGroup = mixerGroups ["SFX"];
			soundObject.SetActive (true);
		}
		if (audioEvent == "laser")
		{
			source.volume = 0.1f;
			source.clip = clips ["laser_raw1"];
			source.outputAudioMixerGroup = mixerGroups ["SFX"];
			soundObject.SetActive (true);
		}
	}

	IEnumerator Wait (string audioEvent, float time)
	{
		yield return new WaitForSeconds (time);

		if (audioEvent == "lowFuel")
			canAlarm = true;
	}
	public void overrideBGMusic(string musicName)
	{
		AudioSource audioSource = GetComponent<AudioSource> ();
		audioSource.clip = clips [musicName];
		audioSource.Play ();
	}
}
