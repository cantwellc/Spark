using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {

    public GameObject door;
    private Vector3 targetPositon;
    private Vector3 velocity = Vector3.zero;
    private bool move = false;

    void Start()
    {
        targetPositon = door.transform.position + new Vector3(0.0f, 0.0f, 10.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        move = true;
    }

    void Update()
    {
        if (move)
            door.transform.position = Vector3.SmoothDamp(door.transform.position, targetPositon, ref velocity, 0.5f);
    }
}
