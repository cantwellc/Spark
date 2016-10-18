using UnityEngine;
using System.Collections;
using System;

public class EmissionLoop : MonoBehaviour {

    private Material material;
    private float brightness;
    public Color color;
    private Color changingColor;
    private bool flag; // To decide whether to increase the brightness or not
	// Use this for initialization
	void Start () {
        material = GetComponent<Renderer>().material;
        color = Color.red;
        brightness = 1.0f;
        flag = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (flag)
        {
            brightness -= 0.05f;
            Math.Round(brightness, 2);
            changingColor = color * brightness;
            material.SetColor("_EmissionColor", changingColor);
            if(brightness <= 0)
            {
                brightness = 0.0f;
                flag = false;
            }
        }
        else
        {
            brightness += 0.05f;
            Math.Round(brightness, 2);
            changingColor = color * brightness;
            material.SetColor("_EmissionColor", changingColor);
            if (brightness >= 1.0f)
            {
                brightness = 1.0f;
                flag = true;
            }
        }
	}
}
