using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class SplineCeiling : MonoBehaviour
{
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
        Array.Reverse(verts);
        var tr = new Triangulator(verts);
        var triangles = tr.Triangulate();
        for(int i=0; i<triangles.Length; i += 3)
        {
            int temp = triangles[i + 0];
            triangles[i + 0] = triangles[i + 1];
            triangles[i + 1] = temp;
        }

        mesh.Clear();
        mesh.vertices = verts;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
       

        meshCollider.sharedMesh = mesh;
    }

    public void ClearMesh()
    {
        mesh.Clear();
        meshCollider.sharedMesh = mesh;
    }
 
}
