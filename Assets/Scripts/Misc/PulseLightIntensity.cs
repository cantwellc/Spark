using UnityEngine;
using System.Collections;

public class PulseLightIntensity : MonoBehaviour {

    public float pulseDuration;
    public float intensityFloor;
    public float intensityCeiling;

    private Light _light;
    [SerializeField]
    private bool _pulse;

    void Awake()
    {
        _light = GetComponent<Light>();
    }

    void Start()
    {
        _pulse = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_pulse) return;
        float intensity = intensityFloor + (Mathf.PingPong(Time.time, pulseDuration) / pulseDuration) * (intensityCeiling - intensityFloor);
        _light.intensity = intensity;
    }
}
