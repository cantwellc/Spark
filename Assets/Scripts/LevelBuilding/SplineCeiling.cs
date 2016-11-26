#if UNITY_EDITOR
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
using TriangleNet.Geometry;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class SplineCeiling : MonoBehaviour
{
    public bool invertNormals;

    [HideInInspector]
    private int _ownerID;

    private MeshFilter _meshFilter;
    protected MeshFilter meshFillter
    {
        get
        {
            _meshFilter = _meshFilter == null ? GetComponent<MeshFilter>() : _meshFilter;
            _meshFilter = _meshFilter == null ? gameObject.AddComponent<MeshFilter>() : _meshFilter;
            return _meshFilter;
        }
    }

    private Mesh _mesh;
    protected Mesh mesh
    {
        get
        {
            bool isOwner = _ownerID == gameObject.GetInstanceID();
            if (meshFillter.sharedMesh == null || !isOwner)
            {
                meshFillter.sharedMesh = _mesh = new Mesh();
                _ownerID = gameObject.GetInstanceID();
                _mesh.name = "Mesh [" + _ownerID + "]";
            }
            return _mesh;
        }
    }

    private MeshCollider _meshCollider;
    protected MeshCollider meshCollider
    {
        get
        {
            _meshCollider = _meshCollider == null ? GetComponent<MeshCollider>() : _meshCollider;
            _meshCollider = _meshCollider == null ? gameObject.AddComponent<MeshCollider>() : _meshCollider;
            return _meshCollider;
        }
    }

    //    public int quadCount = 1;

    //    public float tangentSmoothFactor;
    public SplineWall wall;

    public void DrawMesh()
    {
        var verts = wall.ceilingVertices;
        if(invertNormals) Array.Reverse(verts);

        
        InputGeometry geometry = new InputGeometry();
        List<Point> border = new List<Point>();
        foreach(var vert in verts)
        {
            border.Add(new Point(vert.x, vert.z));
//            geometry.AddPoint(vert.x, vert.z);
        }

        geometry.AddRing(border);
        
//        geometry.AddRegion()
        float yOffset = verts[0].y;
        TriangleNet.Mesh tMesh = new TriangleNet.Mesh();
        tMesh.Triangulate(geometry);

        List<Vector3> vertices = new List<Vector3>(tMesh.triangles.Count * 3);
        List<int> triangles = new List<int>(tMesh.triangles.Count * 3);
        int tIndex = 0;

        foreach(var pair in tMesh.triangles)
        {
            var triangle = pair.Value;
            var v0 = triangle.GetVertex(0);
            var v1 = triangle.GetVertex(1);
            var v2 = triangle.GetVertex(2);

            var p0 = new Vector3(v0.x, yOffset, v0.y);
            var p1 = new Vector3(v1.x, yOffset, v1.y);
            var p2 = new Vector3(v2.x, yOffset, v2.y);

            vertices.Add(p0);
            vertices.Add(p1);
            vertices.Add(p2);

            triangles.Add(tIndex + 2);
            triangles.Add(tIndex + 1);
            triangles.Add(tIndex + 0);

            tIndex += 3;
        }

        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();


        meshCollider.sharedMesh = mesh;
        //var tr = new Triangulator(verts);
        //var triangles = tr.Triangulate();
        //for(int i=0; i<triangles.Length; i += 3)
        //{
        //    int temp = triangles[i + 0];
        //    triangles[i + 0] = triangles[i + 1];
        //    triangles[i + 1] = temp;
        //}

        //mesh.Clear();
        //mesh.vertices = verts;
        //mesh.triangles = triangles;
        //mesh.RecalculateNormals();
        //mesh.RecalculateBounds();


        //meshCollider.sharedMesh = mesh;

    }

    public void ClearMesh()
    {
        mesh.Clear();
        meshCollider.sharedMesh = mesh;
    }
 
}
#endif
