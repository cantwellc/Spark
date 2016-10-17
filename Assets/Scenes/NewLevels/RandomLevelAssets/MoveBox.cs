using UnityEngine;
using System.Collections;

public class MoveBox : MonoBehaviour {

    public GameObject box;
    private Vector3 targetPositon;
    private Vector3 velocity = Vector3.zero;
    private bool move = false;

    void Start()
    {
        if (box != null)
        {
            targetPositon = box.transform.position - new Vector3(0.0f, 0.0f, 5.9f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        move = true;
    }

    void Update()
    {
        if(move && box != null)
        box.transform.position = Vector3.SmoothDamp(box.transform.position, targetPositon, ref velocity, 0.5f);
    }
}
