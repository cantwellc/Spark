using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Audio;

public class MusicVolume : MonoBehaviour {

    public Slider musicVolumeSlider;
    public Text musicVolumeText;

	public AudioMixer musicMixer;

	// Use this for initialization
	void Start () 
	{
        musicVolumeText.text = "Music Volume (" + musicVolumeSlider.value + ")";
    }
	
	// Update is called once per frame
	void Update () 
	{
		musicVolumeText.text = "Music Volume (" + ((int)musicVolumeSlider.value) + ")";
		musicMixer.SetFloat ("mxLevel", (20 * Mathf.Log10(musicVolumeSlider.value * 0.01f)));
    }
}
