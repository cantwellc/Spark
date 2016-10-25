using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MouseIconMeterFill : MonoBehaviour {

    public Image meterFillImage;

    float _startFillTime;
    float _timeToFill;

    public void StartFill(float timeToFill)
    {
        _startFillTime = Time.time;
        _timeToFill = timeToFill;
    }

    public void EmptyFill()
    {
        meterFillImage.fillAmount = 0.0f;
    }

    void Update()
    {
        var ratio = (Time.time - _startFillTime) / _timeToFill;
        meterFillImage.fillAmount = ratio;
    }
}
