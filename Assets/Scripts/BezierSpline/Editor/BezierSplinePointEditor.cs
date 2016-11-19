using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections;

[CustomEditor(typeof(BezierSplinePoint))]
[CanEditMultipleObjects]
public class BezierSplinePointEditor : Editor {
    private static float handleSize = 0.25f;

    private BezierSplinePoint _point;
    protected BezierSplinePoint point
    {
        get
        {
            _point = _point == null ? target as BezierSplinePoint : _point;
            return _point;
        }
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Reset"))
        {
            InitValues();
        }
        base.OnInspectorGUI();
    }

    void OnSceneGUI()
    {
        Handles.color = Color.yellow;
        Handles.DrawLine(point.position, point.controlPoint1);
        EditorGUI.BeginChangeCheck();
        var pos = Handles.FreeMoveHandle(point.controlPoint1, Quaternion.identity, 0.25f, Vector3.zero, Handles.CubeCap);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Changed Control Point 1 Position");
            point.controlPoint1 = pos;
//            EditorUtility.SetDirty(target);
        }

        Handles.DrawLine(point.position, point.controlPoint2);
        EditorGUI.BeginChangeCheck();
        pos = Handles.FreeMoveHandle(point.controlPoint2, Quaternion.identity, 0.25f, Vector3.zero, Handles.CubeCap);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Changed Control Point 2 Position");
            point.controlPoint2 = pos;
//            EditorUtility.SetDirty(target);
        }
    }

    public void InitValues()
    {
        //        Undo.RecordObject(target, "Reset Object");
        point.controlPoint1 = point.position + Vector3.right;
        point.controlPoint2 = point.position + Vector3.left;
        EditorUtility.SetDirty(target);
        //EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }


}
