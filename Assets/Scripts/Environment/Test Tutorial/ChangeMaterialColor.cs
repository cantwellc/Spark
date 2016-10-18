using UnityEngine;
using System.Collections;

public class ChangeMaterialColor : MonoBehaviour {

    public Color color;

    private Material _material;

	void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }
	
	public void SetColor()
    {
        _material.color = color;
    }
}
