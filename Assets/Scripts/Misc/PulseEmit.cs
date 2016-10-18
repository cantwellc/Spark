using UnityEngine;
using System.Collections;

public class PulseEmit : MonoBehaviour {

    public float pulseDuration;
    public float emitFloor;
    public float emitCeiling;

    private Material _material;
    [SerializeField]
    private bool _pulse;
    private Color _emitColor;

    void Awake()
    {
        _material = GetComponent<Renderer>().material;
        _emitColor = _material.GetColor("_EmissionColor");
    }

    void Start()
    {
        _pulse = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!_pulse) return;
        float emission = emitFloor + (Mathf.PingPong(Time.time, pulseDuration) / pulseDuration)*(emitCeiling - emitFloor);
        Color color = _emitColor * Mathf.LinearToGammaSpace(emission);
        _material.SetColor("_EmissionColor", color);
    }
}
