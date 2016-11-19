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
            sc.DrawMesh();
        }
        if (GUILayout.Button("Clear Mesh"))
        {
            var sc = target as SplineWall;
            sc.ClearMesh();
        }
        base.OnInspectorGUI();
    }
}
