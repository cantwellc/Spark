using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PressurePad : MonoBehaviour {

    bool pressured;

    public UnityEvent onPress;
    public UnityEvent onExit;
	public Renderer pressurePadRenderer;
	private Color _original;

	// Use this for initialization
	void Start () 
	{
		_original = pressurePadRenderer.material.GetColor ("_EmissionColor");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Character") return;
		//AudioManager.instance.Play ("pressButton");
		GetComponent<MeshRenderer>().material.color = Color.green;
		pressurePadRenderer.material.SetColor("_EmissionColor", Color.green);
        onPress.Invoke();
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag != "Character") return;
        
		pressurePadRenderer.material.SetColor("_EmissionColor", _original);
        onExit.Invoke();
    }
}
