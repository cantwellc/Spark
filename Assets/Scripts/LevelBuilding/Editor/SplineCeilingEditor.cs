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
            Undo.RecordObject(target, "Draw Mesh");
            sc.DrawMesh();
            EditorUtility.SetDirty(target);
        }
        if (GUILayout.Button("Clear Mesh"))
        {
            var sc = target as SplineCeiling;
            Undo.RecordObject(target, "Clear Mesh");
            sc.ClearMesh();
            EditorUtility.SetDirty(target);
        }
        base.OnInspectorGUI();
    }
}
