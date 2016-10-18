using UnityEngine;
using System.Collections;

public class StopWallMove : MonoBehaviour {
    public GameObject wall;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != wall) return;
        wall.GetComponent<MoveForward>().StopMoving();
    }
}
