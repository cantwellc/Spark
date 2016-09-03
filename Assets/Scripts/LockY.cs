using UnityEngine;
using System.Collections;

public class LockY : MonoBehaviour {
    public float LockPosition;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, LockPosition, transform.position.z);
    }
}
