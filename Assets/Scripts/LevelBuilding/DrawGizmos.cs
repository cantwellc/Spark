using UnityEngine;
using System.Collections;

public class DrawGizmos : MonoBehaviour {

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(0.3f, 0.3f, 0.3f));
    }
}
