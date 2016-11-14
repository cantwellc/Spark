using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MouseCapturePoints : MonoBehaviour {

    public float y;

    public bool toClear = false;
    public bool toRename = false;

    // Use this for initialization
    void Start () {
	
	}


    /*void OnSceneGUI()
    {
        Event e = Event.current;
        switch (e.type)
        {
            case EventType.keyDown:
                {
                    if (Event.current.keyCode == (KeyCode.A))
                    {
                        print("a");
                    }
                    break;
                }
        }
    }*/

    void OnDrawGizmosSelected()
    {
       // Gizmos.color = Color.yellow;
        //Gizmos.DrawWireCube(transform.position, new Vector3(1, 1, 1));
    }

    // Update is called once per frame
    void Update () {
        if (toClear)
        {
            print("cleared");
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }

            toClear = false;
        }
        if(toRename)
        {
            for (int i = 0; i != transform.childCount; ++i)
            {
                transform.GetChild(i).gameObject.name = i.ToString();
            }
            toRename = false;

        }
    }
}
