using UnityEngine;
using System.Collections;

public class DoorClosed : MonoBehaviour {

    public GameObject door;
    private Vector3 targetPositon;
    private Vector3 velocity = Vector3.zero;
    private bool move = false;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        targetPositon = door.transform.position - new Vector3(0.0f, 0.0f, 14.0f);
        gameObject.transform.position += new Vector3(-30.0f,0.0f,0.0f);
        move = true;
    }

    void Update()
    {
        if (move)
            door.transform.position = Vector3.SmoothDamp(door.transform.position, targetPositon, ref velocity, 0.2f);
    }
}
