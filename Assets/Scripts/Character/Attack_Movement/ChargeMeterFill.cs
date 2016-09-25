using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChargeMeterFill : MonoBehaviour {

    public Image fillImage;
    public FireBehavior fireBehavior;

    private bool _charging;

    public void Charging()
    {
        _charging = true;
    }
    public void ChargeComplete()
    {
        _charging = false;
    }
    public void ChargeDepleted()
    {
        _charging = false;
        fillImage.fillAmount = 0.0f;
    }

    void Update()
    {
        if (!_charging) return;
        fillImage.fillAmount = fireBehavior.ChargeRatio;
    }
}
