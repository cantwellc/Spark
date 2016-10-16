using UnityEngine;
using System.Collections;

public class PulseEmit : MonoBehaviour {

    public float pulseDuration;
    public float emitFloor;
    public float emitCeiling;
    public Color emitColor;

    private Material _material;
    [SerializeField]
    private bool _pulse;

	void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    void Start()
    {
        _pulse = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!_pulse) return;
        float emission = emitFloor + (Mathf.PingPong(Time.time, pulseDuration) / pulseDuration)*(emitCeiling - emitFloor);
        Color color = emitColor * Mathf.LinearToGammaSpace(emission);
        _material.SetColor("_EmissionColor", color);
    }
}
