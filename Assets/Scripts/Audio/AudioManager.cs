using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

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
	private GameObject leechBeam;

	private string previousScene;

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
		//Changes BGM depending on scene
		if (audioEvent == "standardLevel") 
		{
			AudioSource musicSource = gameObject.GetComponent<AudioSource> ();
			musicSource.clip = clips ["Menu_Music_2"];
			musicSource.Play ();
		}
			
		//Stops death countdown SFX
		if (audioEvent == "stopDeathCountdown") 
		{
			if (alarm != null) 
			{
				alarm.GetComponent<AudioSource> ().loop = false;
				alarm.SetActive (false);
				return;
			}
		}
	
		//Stops ambient leech beam sound
		if (audioEvent == "leechRelease") 
		{
			if (leechBeam != null) 
			{
				leechBeam.GetComponent<AudioSource> ().loop = false;
				leechBeam.SetActive (false);
				return;
			}
		}

		//Assigns SFX to object in pool
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

		//Grows object ppol
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

		//Assigns audio source component of sound object to "source" variable
		AudioSource source = soundObject.GetComponent<AudioSource> ();

		//Initalizes source
		source.spatialBlend = 0.0f;
		source.volume = 1.0f;
		source.loop = false;

		//Plays the various SFX
		if (audioEvent == "standardLevel")
		{
			snapshots ["DefaultMX"].TransitionTo (0.0f);
			GetComponent<AudioSource> ().Play ();
		}

		if (audioEvent == "chaseLevel")
		{
			snapshots ["BossLevel"].TransitionTo (0.0f);
			GetComponent<AudioSource> ().Stop ();
			source.clip = clips ["ChaseLevelMusic"];
			source.outputAudioMixerGroup = mixerGroups ["BossBGM"];
			source.loop = true;
			soundObject.SetActive (true);
		}

		if (audioEvent == "bossLevel") 
		{
			snapshots ["BossLevel"].TransitionTo (0.0f);
			GetComponent<AudioSource> ().Stop ();
			source.clip = clips ["boss_music2"];
			source.outputAudioMixerGroup = mixerGroups ["BossBGM"];
			source.loop = true;
			soundObject.SetActive (true);
		}

		if (audioEvent == "plasmaFire") 
		{
			source.clip = clips ["plasmaFire"];
			source.outputAudioMixerGroup = mixerGroups ["PrimaryFire"];
			soundObject.SetActive (true);
		}

		if (audioEvent == "burstCharge") 
		{
			snapshots ["SFXDefault"].TransitionTo (0.0f);
			source.clip = clips ["burstCharge"];
			source.outputAudioMixerGroup = mixerGroups ["SecondaryCharge"];
			soundObject.SetActive (true);
		}

		if (audioEvent == "burstFire") 
		{
			snapshots ["ChargeOff"].TransitionTo (0.5f);
			source.clip = clips ["plasmaBurst"];
			source.outputAudioMixerGroup = mixerGroups ["SecondaryFire"];
			soundObject.SetActive (true);
		}

		if (audioEvent == "cantFire") 
		{
			source.clip = clips ["attackFail"];
			source.outputAudioMixerGroup = mixerGroups ["PrimaryFire"];
			soundObject.SetActive (true);
		}

		if (audioEvent == "lowFuel") 
		{
			if (canAlarm) 
			{
				canAlarm = false;
				source.clip = clips ["lowFuel"];
				source.loop = true;
				alarm = soundObject;
				source.outputAudioMixerGroup = mixerGroups ["Alarm"];
				soundObject.SetActive (true);
				StartCoroutine (Wait (audioEvent, source.clip.length));
			}
		}

		if (audioEvent == "stopLowFuelAlarm") 
		{
			StartCoroutine (Wait (audioEvent, 1.2f));
		}

		if (audioEvent == "refuel") 
		{
			source.clip = clips ["refuel"];
			source.outputAudioMixerGroup = mixerGroups ["Refuel"];
			soundObject.SetActive (true);
		}

		if (audioEvent == "deathCountdown") 
		{
			source.clip = clips ["destructCountdown2"];
			source.outputAudioMixerGroup = mixerGroups ["Alarm"];
			soundObject.SetActive (true);
			alarm.SetActive (false);
			alarm = soundObject;
		}

		if (audioEvent == "death") 
		{
			source.clip = clips ["explosionPlayer" + (int)Random.Range(1,3)];
			source.outputAudioMixerGroup = mixerGroups ["Explosions"];
			Play ("stopDeathCountdown");
			soundObject.SetActive (true);
		}

		if (audioEvent == "openPortal")
		{
			source.clip = clips ["openPortal"];
			source.outputAudioMixerGroup = mixerGroups ["Portal"];
			soundObject.SetActive (true);
		}

		if (audioEvent == "leechHold") 
		{
			source.clip = clips ["leechDroneBeam"];
			source.loop = true;
			source.outputAudioMixerGroup = mixerGroups ["LeechBeam"];
			soundObject.SetActive (true);
			leechBeam = soundObject;
		}

		if (audioEvent == "keycharge")
		{
			source.clip = clips ["keyCharge"];
			source.outputAudioMixerGroup = mixerGroups ["KeyCharge"];
			soundObject.SetActive (true);
		}

		if (audioEvent == "keyRelease") 
		{
			source.clip = clips ["keyDetatch"];
			source.outputAudioMixerGroup = mixerGroups ["KeyRelease"];
			soundObject.SetActive (true);
		}

        if (audioEvent == "slowAura")
        {

            source.volume = 0.1f;
            source.clip = clips["refuel_raw3"];
            source.outputAudioMixerGroup = mixerGroups["SFX"];
            soundObject.SetActive(true);
        }
        //For green floors speed up effect SFX
        if (audioEvent == "speedUpAura")
        {
            source.volume = 0.5f;
            source.clip = clips["chargeUp_raw2"];
            source.outputAudioMixerGroup = mixerGroups["SFX"];
            soundObject.SetActive(true);
        }
        if(audioEvent == "temporaryDrag")
        {
            source.volume = 0.5f;
            source.clip = clips["wormholeOpen_raw1"];
            source.outputAudioMixerGroup = mixerGroups["SFX"];
            soundObject.SetActive(true);
        }
        if (audioEvent == "evilLaugh")
		{
			source.clip = clips ["evilLaugh" + (int)Random.Range(1,5)];
			source.outputAudioMixerGroup = mixerGroups ["Laugh"];
			soundObject.SetActive (true);
		}

		if (audioEvent == "characterDamage") 
		{
			source.clip = clips ["explosionSm" + (int)Random.Range (1, 3)];
			source.outputAudioMixerGroup = mixerGroups ["TakeDamage"];
			soundObject.SetActive (true);
		}
	}

	//Overload function for 3D sounds
	public void Play(string audioEvent, GameObject pos)
	{
		//Assigns SFX to object in pool
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

		//Grows object ppol
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

		//Places the sound object at the position of the object making the sound
		soundObject.transform.position = pos.transform.position;

		//Assigns audio source component of sound object to "source" variable
		AudioSource source = soundObject.GetComponent<AudioSource> ();

		//Initalizes source (3D)
		source.spatialBlend = 1.0f;
		source.volume = 1.0f;
		source.loop = false;

		if (source.volume != 1.0f)
			source.volume = 1.0f;

		if (audioEvent == "droneExplode") 
		{
			source.clip = clips ["explosionSm" + (int)Random.Range (1,3)];
			source.outputAudioMixerGroup = mixerGroups ["Explosions"];
			soundObject.SetActive (true);
		}

		if (audioEvent == "enemyDeath") 
		{
			source.clip = clips ["explosionLg" + (int)Random.Range(1,3)];
			source.outputAudioMixerGroup = mixerGroups ["Explosions"];
			soundObject.SetActive (true);
		}

		if (audioEvent == "bossDeath") 
		{
			source.clip = clips ["bossDeath"];
			source.outputAudioMixerGroup = mixerGroups ["Explosions"];
			soundObject.SetActive (true);
		}

		if (audioEvent == "takeDamage")
		{
			source.clip = clips ["explosionSm" + (int)Random.Range(1,3)];
			source.outputAudioMixerGroup = mixerGroups ["TakeDamage"];
			soundObject.SetActive (true);
		}

		if (audioEvent == "bossTakeDamage")
		{
			source.clip = clips ["explosionSm" + (int)Random.Range(1,3)];
			source.outputAudioMixerGroup = mixerGroups ["TakeDamage"];
			soundObject.SetActive (true);
		}

		if (audioEvent == "laser")
		{
			source.clip = clips ["leechDroneShot"];
			source.outputAudioMixerGroup = mixerGroups ["EnemyFire"];
			soundObject.SetActive (true);
			Play ("leechHold");
		}
	}

	//Use to set a delay between audio events, etc.
	IEnumerator Wait (string audioEvent, float time)
	{

		if (audioEvent == "stopLowFuelAlarm" && alarm != null) 
		{
			snapshots ["AlarmOff"].TransitionTo (1.0f);
			yield return new WaitForSeconds (time);
			alarm.SetActive (false);
			canAlarm = true;
			snapshots ["SFXDefault"].TransitionTo (0.0f);
		}
		else
			yield return new WaitForSeconds (time);

		if (audioEvent == "lowFuel")
			canAlarm = true;
	}

	public void overrideBGMusic(string musicName)
	{
		/*AudioSource audioSource = GetComponent<AudioSource> ();
		audioSource.clip = clips [musicName];
		audioSource.Play ();*/
	}

	public void DisableDeadCountDownSound()
	{
		//GetComponent<AudioSource> ().loop = false;
	}

}
