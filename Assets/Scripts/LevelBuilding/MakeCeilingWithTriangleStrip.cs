using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MakeCeilingWithTriangleStrip : MonoBehaviour {
    public bool createMesh;
    public bool clearMesh;


    public GameObject wallPoints;
    public int startIndex;
    public int endIndex;
    public GameObject endPoints;

    public Transform centerPoint;
    public bool upwards;
    public float wallHeight;

    Vector3[] vertices;
    Vector2[] uvs;
    Vector3[] normals;
    int[] triangles;

    Mesh mesh;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (createMesh == true)
        {
            createMesh = false;
            if (wallPoints != null)
            {
                mesh = new Mesh();

                int childCount = (endIndex-startIndex) + endPoints.transform.childCount+2;
                vertices = new Vector3[childCount + 1];
                normals = new Vector3[childCount + 1];
                uvs = new Vector2[childCount + 1];
                triangles = new int[childCount * 3];
                
                vertices[0] = centerPoint.position;
                normals[0] = Vector3.up;
                uvs[0] = new Vector2(0.5f, 0.0f);
                for (int a = 0; a <= endIndex - startIndex; ++a)
                {
                    Vector3 pos = wallPoints.transform.GetChild(a+startIndex).position;
                    pos.y += wallHeight;
                    vertices[a +1] = pos;
                    normals[a+1] = Vector3.up;

                    if (a % 2 == 0)
                    {
                        uvs[a+1] = new Vector2(0.0f, 1.0f);
                    }
                    else
                    {
                        uvs[a + 1] = new Vector2(1.0f, 1.0f);
                    }

                }

                int end = endIndex - startIndex+1;
                for (int a = 0; a < endPoints.transform.childCount; ++a)
                {
                    Vector3 pos = endPoints.transform.GetChild(a).position;
                    pos.y += wallHeight;
                    vertices[a + end + 1] = pos;

                    if ((a + end) % 2 == 0)
                    {
                        uvs[a +end + 1] = new Vector2(0.0f, 1.0f);
                    }
                    else
                    {
                        uvs[a + end + 1] = new Vector2(1.0f, 1.0f);
                    }

                }

                Vector3 pos1 = wallPoints.transform.GetChild(startIndex).position;
                pos1.y += wallHeight;
                int last = end + endPoints.transform.childCount;
                vertices[last+1] = pos1;

                if (last % 2 == 0)
                {
                    uvs[last + 1] = new Vector2(0.0f, 1.0f);
                }
                else
                {
                    uvs[last + 1] = new Vector2(1.0f, 1.0f);
                }


                for (int a = 0; a <= end+ endPoints.transform.childCount-1; ++a)
                {
                    triangles[a * 3] = 0;
                    if (upwards)
                    {
                        triangles[a * 3 + 1] = a + 1;
                        triangles[a * 3 + 2] = a + 2;
                    }
                    else
                    {

                        triangles[a * 3 + 1] = a + 2;
                        triangles[a * 3 + 2] = a + 1;
                    }
                }


                mesh.vertices = vertices;
                mesh.uv = uvs;
                mesh.triangles = triangles;

                mesh.name = "Generated mesh";
                GetComponent<MeshFilter>().mesh = mesh;
            }

        }
        if (clearMesh)
        {
            clearMesh = false;
            GetComponent<MeshFilter>().mesh = null;
        }
    }
}
