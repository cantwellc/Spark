using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(SplineCeiling))]
public class SplineCeilingEditor : Editor {

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Draw Mesh"))
        {
            var sc = target as SplineCeiling;
            sc.DrawMesh();
        }
        if (GUILayout.Button("Clear Mesh"))
        {
            var sc = target as SplineCeiling;
            sc.ClearMesh();
        }
        base.OnInspectorGUI();
    }
}
