using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MouseIconMeterFill : MonoBehaviour {

    public Image meterFillImage;

    bool _filling;
    float _startFillTime;
    float _timeToFill;

    public void StartFill(float timeToFill)
    {
        _filling = true;
        _startFillTime = Time.time;
        _timeToFill = timeToFill;
    }

    public void EmptyFill()
    {
        _filling = false;
        meterFillImage.fillAmount = 0.0f;
    }

    void Update()
    {
        if (!_filling) return;
        var ratio = (Time.time - _startFillTime) / _timeToFill;
        meterFillImage.fillAmount = ratio;
    }
}
