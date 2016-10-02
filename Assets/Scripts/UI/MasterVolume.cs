using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Audio;

public class MasterVolume : MonoBehaviour {

    public Slider masterVolumeSlider;
    public Text masterVolumeText;

	public AudioMixer masterMixer;

	// Use this for initialization
	void Start () 
	{
		masterVolumeText.text = "Master Volume (" + masterVolumeSlider.value + ")";
    }
	
	// Update is called once per frame
	void Update () 
	{
		masterVolumeText.text = "Master Volume (" + ((int)masterVolumeSlider.value) + ")";
		masterMixer.SetFloat ("masterLevel", (20 * Mathf.Log10(masterVolumeSlider.value * 0.01f)));
    }
}
