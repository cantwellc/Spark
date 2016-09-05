using UnityEngine;
using System.Collections;

public class VolumeAdjustment : MonoBehaviour {
	
	public AudioSource musicObject;

	// Use this for initialization
	void Start () {
		musicObject = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			if(musicObject.volume < 1.0f){
				musicObject.volume += 0.1f;
			}
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (musicObject.volume > 0.0f) {
				musicObject.volume -=0.1f;
			}
		}
	}
}
