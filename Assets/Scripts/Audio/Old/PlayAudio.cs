using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {

	public AudioSource music;
	public AudioSource backgroundSFX;
	public float playMin;
	public float playMax;
	private float _randomPlayAfter;
	private float _currentCounter;


	// Use this for initialization
	void Start () {

		music.time =Random.Range (20.0f,65.0f);
		music.Play ();
		_randomPlayAfter = Random.Range (playMin, playMax);
		_currentCounter = 0;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_currentCounter > _randomPlayAfter )
		{
			_currentCounter = 0;
			backgroundSFX.Play ();
			_randomPlayAfter = Random.Range (playMin, playMax);
		}
		_currentCounter += Time.deltaTime;
	}
}
