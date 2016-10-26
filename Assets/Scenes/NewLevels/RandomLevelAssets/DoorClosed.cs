using UnityEngine;
using System.Collections;

public class DoorClosed : MonoBehaviour {

    public GameObject door;
    public Transform target;
    private Vector3 targetPositon;
    public bool targetSupplied = false;
    private Vector3 velocity = Vector3.zero;
    private bool move = false;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
       
        if (other.tag != "Character") return;
        if (!targetSupplied)
            targetPositon = door.transform.position - new Vector3(0.0f, 0.0f, 14.0f);
        else if (targetSupplied)
            targetPositon = target.transform.position;
        gameObject.transform.position += new Vector3(-30.0f,0.0f,0.0f);
        move = true;
        GetComponent<MEvent>().TriggerEvent();
    }

    void Update()
    {
        if (move)
            door.transform.position = Vector3.SmoothDamp(door.transform.position, targetPositon, ref velocity, 0.2f);
    }
}
