﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChargeMeterFill : MonoBehaviour {

    public Image fillImage;
    public FireBehavior fireBehavior;

    public bool _charging;

	void Awake()
	{
		fillImage.fillAmount = 0.0f;
	}

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
