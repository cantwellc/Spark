using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(SplineWall))]
public class SplineWallEditor : Editor
{

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Draw"))
        {
            var sc = target as SplineWall;
            Undo.RecordObject(target, "Draw Mesh");
            sc.BroadcastDraw();
            EditorUtility.SetDirty(target);
        }
        if (GUILayout.Button("Clear Mesh"))
        {
            var sc = target as SplineWall;
            Undo.RecordObject(target, "Clear Mesh");
            sc.BroadcastClear();
            EditorUtility.SetDirty(target);
        }
        base.OnInspectorGUI();
    }
}
