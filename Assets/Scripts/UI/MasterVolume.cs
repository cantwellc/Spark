using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MasterVolume : MonoBehaviour {

    public Slider masterVolumeSlider;
    public Text masterVolumeText;

	// Use this for initialization
	void Start () {
        masterVolumeText.text = "Master Volume (" + masterVolumeSlider.value + ")";

    }
	
	// Update is called once per frame
	void Update () {
        masterVolumeText.text = "Master Volume (" + masterVolumeSlider.value + ")";
    }
}
