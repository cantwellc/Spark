#if UNITY_EDITOR
using UnityEngine;

using UnityEditor;


using System.Collections;

[CustomEditor(typeof(MouseCapturePoints))]
public class MouseCapturePointsEditor : Editor {

    MouseCapturePoints point;

    SerializedProperty toClear;
    SerializedProperty toRename;
    SerializedProperty y;

    GameObject childPrefab;

    // Use this for initialization
    void Start () {
	
	}

    void OnEnable()
    {
        point = (MouseCapturePoints)target;
        toClear = serializedObject.FindProperty("toClear");
        toRename = serializedObject.FindProperty("toRename");
        y = serializedObject.FindProperty("y");

        childPrefab = (GameObject) Resources.Load("Prefabs/UI/CubeGizmos");
    }

    void OnSceneGUI()
    {
        Event e = Event.current;
        if (Event.current.type == EventType.MouseDown && Event.current.button == 1)
        {
            Vector3 planePos = point.transform.position;
            planePos.y = point.y;
            Plane wallPlane = new Plane(Vector3.up, planePos);
            Vector2 mousePos = Event.current.mousePosition;
            mousePos.y = Camera.current.pixelHeight - mousePos.y;
            Vector3 position = Camera.current.ScreenPointToRay(mousePos).origin;

            Ray ray = Camera.current.ScreenPointToRay(mousePos);
            float hitdist = 0.0f;
            // If the ray is parallel to the plane, Raycast will return false.
            if (wallPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);
                //Debug.DrawRay(Camera.current.transform.position, targetPoint, Color.red);
                GameObject obj = (GameObject)Instantiate(childPrefab);
                obj.transform.position = targetPoint;
                obj.transform.parent = point.transform;

            }
            
            
        }
        switch (e.type)
        {
            case EventType.keyDown:
                {
                    if (Event.current.keyCode == (KeyCode.A))
                    {
                        
                    }
                    break;
                }

        }
    }

    public override void OnInspectorGUI()
    {
        //serializedObject.Update();
        //EditorGUILayout.PropertyField(lookAtPoint);
        //EditorGUILayout.LabelField("(Below this object)");
        EditorGUILayout.PropertyField(toClear);
        EditorGUILayout.PropertyField(toRename);
        EditorGUILayout.PropertyField(y);
        serializedObject.ApplyModifiedProperties();
    }
}
#endif