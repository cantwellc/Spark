using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundEffectVolume : MonoBehaviour {

    public Slider soundEffectVolumeSlider;
    public Text soundEffectVolumeText;

	// Use this for initialization
	void Start () {
        soundEffectVolumeText.text = "Sound Effect Volume (" + soundEffectVolumeSlider.value + ")";

    }
	
	// Update is called once per frame
	void Update () {
        soundEffectVolumeText.text = "Sound Effect Volume (" + soundEffectVolumeSlider.value + ")";
    }
}
