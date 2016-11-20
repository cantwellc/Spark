using UnityEngine;
using UnityEditor;
using System.Collections;

public class SplinePivot : MonoBehaviour {

    public Vector3 position
    {
        get
        {
            return transform.position;
        }
    }

	//void OnDrawGizmos()
 //   {
 //       Gizmos.color = Color.yellow;
 //       Gizmos.DrawWireSphere(transform.position, 0.25f);
 //   }

}

public class SplinePivotGizmoDrawer
{
    [DrawGizmo(GizmoType.Pickable | GizmoType.InSelectionHierarchy | GizmoType.NotInSelectionHierarchy)]
    private static void DrawGizmo( SplinePivot sp, GizmoType gizmoType)
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(sp.position, 0.25f);
    }
}
