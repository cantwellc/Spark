#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;

public class SplinePivot : MonoBehaviour {

    private bool _c1Set;
    private Vector3 _controlPoint1;

    private bool _c2Set;
    private Vector3 _controlPoint2;

    private BezierSpline _spline;
    protected BezierSpline spline
    {
        get
        {
            _spline = spline == null ? GetComponentInParent<BezierSpline>() : _spline;
            if (_spline == null) Debug.Log(gameObject.name + " must be a child of a GameObject with a BezierSpline component.");
            return _spline;
        }
    }

    public Vector3 position
    {
        get
        {
            return transform.position;
        }
    }

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
#endif
