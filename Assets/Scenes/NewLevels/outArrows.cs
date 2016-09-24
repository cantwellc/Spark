using UnityEngine;
using System.Collections;

public class outArrows : MonoBehaviour {

    public GameObject arrows;

    void Flash()
    {
        if (arrows.activeSelf)
            arrows.SetActive(false);
        else
            arrows.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        arrows.SetActive(true);
        InvokeRepeating("Flash", 1.0f, 1.0f);
    }
}
