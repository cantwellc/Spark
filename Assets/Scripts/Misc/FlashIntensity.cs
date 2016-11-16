using UnityEngine;
using System.Collections;

public class FlashIntensity : MonoBehaviour {

    public float holdTime;
    public float flashIntensity;

    private Light _light;
    private float _baseIntensity;

    void Awake()
    {
        _light = GetComponent<Light>();
        _baseIntensity = _light.intensity;
    }

    public void Flash()
    {
        StartCoroutine(CoFlash());
    }

    private IEnumerator CoFlash()
    {
        _light.intensity = flashIntensity;
        yield return new WaitForSeconds(holdTime);
        _light.intensity = _baseIntensity;
    }
}
