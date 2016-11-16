using UnityEngine;
using System.Collections;
using System;

public class FlashEmit : MonoBehaviour {

    public float holdTime;
    public float emitFlash;

    private Material _material;
    [SerializeField]
    private Color _emitInitColor;
    [SerializeField]
    private Color _flashColor;
    private bool _flash;

    void Start()
    {
        _material = GetComponent<Renderer>().material;
        _emitInitColor = _material.GetColor("_EmissionColor");
    }

    void Update()
    {
        _flashColor = _emitInitColor * Mathf.LinearToGammaSpace(emitFlash);
        if (_flash)
        {
            _material.SetColor("_EmissionColor", _flashColor);
            StartCoroutine(WaitTime());
        }
        else
            _material.SetColor("_EmissionColor", _emitInitColor);
    }

    public void Flash()
    {
        _flash = true;
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(holdTime);
        _flash = false;
    }
}
