using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Audio;

public class SoundEffectVolume : MonoBehaviour {

    public Slider soundEffectVolumeSlider;
    public Text soundEffectVolumeText;

	public AudioMixer sfxMixer;

	// Use this for initialization
	void Start () 
	{
        soundEffectVolumeText.text = "Sound Effects Volume (" + soundEffectVolumeSlider.value + ")";
    }
	
	// Update is called once per frame
	void Update () 
	{
		soundEffectVolumeText.text = "Sound Effects Volume (" + ((int)soundEffectVolumeSlider.value) + ")";
		sfxMixer.SetFloat ("sfxLevel", (20 * Mathf.Log10(soundEffectVolumeSlider.value * 0.01f)));
    }
}
