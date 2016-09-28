using UnityEngine;
using System.Collections;

public class ObjectDeactivator : MonoBehaviour {
    public GameObject target;

    public void Deactivate()
    {
        target.SetActive(false);
    }
}
