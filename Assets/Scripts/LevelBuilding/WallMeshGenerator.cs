using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class WallMeshGenerator : MonoBehaviour {

    public GameObject WallPoints;

    public bool createMesh;
    public bool clearMesh;

    public float wallHeight;
    public float wallWidth;

    Vector3[] vertices;
    Vector2[] uvs;
    Vector3[] normals;
    int[] triangles;

    Mesh mesh;

	// Use this for initialization
	void Start () {
	
	}
	
    void PushTriangles(int index, int v1, int v2, int v3)
    {
        triangles[index] = v1;
        triangles[index+1] = v2;
        triangles[index+2] = v3;
    }

    void PushTriangles(int index, int v1, int v2, int v3,int v4)
    {
        triangles[index] = v1 + index/36*4;
        triangles[index + 1] = v2 + index / 36 * 4;
        triangles[index + 2] = v3 + index / 36 * 4;
        triangles[index+3] = v3 + index / 36 * 4;
        triangles[index + 4] = v2 + index / 36 * 4;
        triangles[index + 5] = v4 + index / 36 * 4;
    }

    // Update is called once per frame
    void Update () {
	    if(createMesh == true)
        {
            createMesh = false;
            if(WallPoints != null)
            {
                mesh = new Mesh();

                int childCount = WallPoints.transform.childCount;
                vertices = new Vector3[childCount * 4];
                uvs = new Vector2[childCount * 4];
                normals = new Vector3[childCount * 4]; 
                triangles = new int[childCount * 6 * 2*3];

                int ind ;
                Vector3 pos1;
                Vector3 pos2;
                for (int a=0;a<WallPoints.transform.childCount;++a)
                {
                    Transform [] child = new Transform[2];
                    child[0] = WallPoints.transform.GetChild(a);
                    if(a < WallPoints.transform.childCount-1)
                        child[1] = WallPoints.transform.GetChild(a+1);
                    else
                    {
                        child[0] = WallPoints.transform.GetChild(a);
                        child[1] = WallPoints.transform.GetChild(a-1);
                    }
                    Vector3 wallDir = child[1].position - child[0].position;
                    if (a == WallPoints.transform.childCount - 1)
                        wallDir = -wallDir;

                    Vector3 wallWidthDir = Vector3.Cross(wallDir.normalized, Vector3.up);
                    if(a>0)
                    {
                        Vector3 lastPos = WallPoints.transform.GetChild(a - 1).position;
                        Vector3 lastDir = (child[0].position - lastPos).normalized;
                        lastDir = Vector3.Cross(lastDir.normalized, Vector3.up);
                        wallWidthDir = (wallWidthDir + lastDir).normalized;
                    }
                    pos1 = child[0].position;
                    pos2 = child[1].position;
                    vertices[4*a] = pos1;
                    normals[4 * a] = -wallWidthDir;
                    vertices[4 * a+1] = pos1;
                    vertices[4 * a + 1].y += wallHeight;
                    normals[4 * a+1] = -wallWidthDir;
                    vertices[4 * a+2] = pos1;
                    vertices[4 * a + 2] += wallWidth*wallWidthDir;
                    normals[4 * a + 2] = wallWidthDir;
                    vertices[4 * a+3] = pos1;
                    vertices[4 * a + 3].y += wallHeight;
                    vertices[4 * a + 3] += wallWidth*wallWidthDir;
                    normals[4 * a + 3] = wallWidthDir;

                    if (a%2 == 0)
                    {
                        uvs[4 * a] = new Vector2(0.0f, 0.0f);
                        uvs[4 * a+1] = new Vector2(0.0f, 1.0f);
                        uvs[4 * a+2] = new Vector2(1.0f, 0.0f);
                        uvs[4 * a+3] = new Vector2(1.0f, 1.0f);
                    }
                    else
                    {
                        uvs[4 * a] = new Vector2(1.0f, 0.0f);
                        uvs[4 * a + 1] = new Vector2(1.0f, 1.0f);
                        uvs[4 * a + 2] = new Vector2(0.0f, 0.0f);
                        uvs[4 * a + 3] = new Vector2(0.0f, 1.0f);
                    }
                    
                }
                for (int a = 0; a < WallPoints.transform.childCount-1; ++a)
                {
                    ind = 36 * a;
                    PushTriangles(ind, 0 , 2 , 1, 3);
                    PushTriangles(ind + 6, 0  , 1  , 4  , 5  );
                    PushTriangles(ind + 12, 1  , 3  , 5  , 7  );
                    PushTriangles(ind + 18, 2  , 6  , 3  , 7  );
                    PushTriangles(ind + 24, 0  , 4  , 2  , 6  );
                    PushTriangles(ind + 30, 4  , 5  , 6  , 7  );
                }

                mesh.vertices = vertices;
                mesh.uv = uvs;
                mesh.normals = normals;
                mesh.triangles = triangles;

                mesh.name = "Generated mesh";
                GetComponent<MeshFilter>().mesh = mesh;
                if(gameObject.GetComponent<MeshCollider>() == null)
                    gameObject.AddComponent<MeshCollider>();
            }
            
        }
        if(clearMesh)
        {
            clearMesh = false;
            GetComponent<MeshFilter>().mesh = null;
            DestroyImmediate(GetComponent<MeshCollider>());
        }
	}
}
