using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImagePulseColor : MonoBehaviour {
    public Color color1;
    public Color color2;
    public float pulseDuration;

    private Image _image;
    private bool _pulse;

    void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void StartPulsing()
    {
        _pulse = true;
    }

    public void StopPulsing()
    {
        _pulse = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!_pulse) return;
        float lerp = Mathf.PingPong(Time.time, pulseDuration) / pulseDuration;
        _image.color = Color.Lerp(color1, color2, lerp);
    }
}
