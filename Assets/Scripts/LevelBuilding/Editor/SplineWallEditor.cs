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
            sc.BroadcastDraw();
        }
        if (GUILayout.Button("Clear Mesh"))
        {
            var sc = target as SplineWall;
            sc.BroadcastClear();
        }
        base.OnInspectorGUI();
    }
}
