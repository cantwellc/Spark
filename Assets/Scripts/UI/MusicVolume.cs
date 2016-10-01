using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicVolume : MonoBehaviour {

    public Slider musicVolumeSlider;
    public Text musicVolumeText;

	// Use this for initialization
	void Start () {
        musicVolumeText.text = "Music Volume (" + musicVolumeSlider.value + ")";

    }
	
	// Update is called once per frame
	void Update () {
        musicVolumeText.text = "Music Volume (" + musicVolumeSlider.value + ")";
    }
}
