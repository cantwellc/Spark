using UnityEngine;
using System.Collections;

public class SplinePivot : MonoBehaviour {

	void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.25f);
    }
}
