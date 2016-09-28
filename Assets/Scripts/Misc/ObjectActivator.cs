using UnityEngine;
using System.Collections;

public class ObjectActivator : MonoBehaviour {
    public GameObject target;
	
    public void Activate()
    {
        target.SetActive(true);
    }
}
