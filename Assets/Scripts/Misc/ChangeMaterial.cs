using UnityEngine;
using System.Collections;

public class ChangeMaterial : MonoBehaviour {
    public Material material;

    public void SetMaterial()
    {
        GetComponent<Renderer>().material = material;
    }
}
