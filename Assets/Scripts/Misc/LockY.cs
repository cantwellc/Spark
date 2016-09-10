using UnityEngine;
using System.Collections;

public class LockY : MonoBehaviour 
{
    public float lockPosition;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, lockPosition, transform.position.z);
    }
}
