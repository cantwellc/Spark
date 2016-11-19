using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(BezierSpline))]
public class SplineWall : MonoBehaviour {
    public struct OrientedPoint
    {
        public Vector3 position;
        public Quaternion rotation;
        public OrientedPoint(Vector3 position, Quaternion rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }

        public Vector3 LocalToWorld( Vector3 point )
        {
            Vector3 rotatedPoint = rotation * point;
            Vector3 translatedPoint = position + rotatedPoint;
            return translatedPoint;
        }

        public Vector3 WorldToLocal( Vector3 point)
        {
            return Quaternion.Inverse(rotation) * (point - position);
        }

        public Vector3 LocalToWorldDirection(Vector3 dir)
        {
            return rotation * dir;
        }
    }

    public struct WallExtrudeShape
    {
        public Vector2[] verts;
        public Vector2[] normals;
        public float[] us;
        public int[] lines;

        public WallExtrudeShape(float h)
        {
            verts = new Vector2[2];
            verts[0] = new Vector2(0.0f, 0.0f);
            verts[1] = new Vector2(0.0f, h);
            normals = new Vector2[2];
            normals[0] = new Vector2(1.0f, 0.0f);
            normals[1] = new Vector2(1.0f, 0.0f);
            us = new float[2];
            us[0] = 0.0f;
            us[1] = 1.0f;
            lines = new int[] { 0, 1 };
        }
    }

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
            if( meshFillter.sharedMesh == null || !isOwner)
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
    

    private BezierSpline _spline;
    private Vector3[] _vertices;
    private Vector2[] _uvs;
    private Vector3[] _normals;
    private int[] _triangles;

    private Vector3[] _ceilingVertices;
    public Vector3[] ceilingVertices
    {
        get
        {
            return _ceilingVertices;
        }
    }

    //public bool createMesh;
    //public bool clearMesh;

    public int segments = 1;
    public float wallHeight = 1;
    public bool reverseNormals;

    // Update is called once per frame
    //void Update()
    //{
    //    if (createMesh == true)
    //    {
    //        createMesh = false;
    //        var shape = new WallExtrudeShape(wallHeight);
    //        OrientedPoint[] path = GetPathFromSpline();
    //        int edgeLoops = path.Length;
    //        int vertsInShape = shape.verts.Length;
    //        int vertCount = vertsInShape * edgeLoops;
    //        int triCount = shape.lines.Length * segments;
    //        int triIndexCount = triCount * 3;

    //        _triangles = new int[triIndexCount];
    //        _vertices = new Vector3[vertCount];
    //        _normals = new Vector3[vertCount];
    //        _uvs = new Vector2[vertCount];

    //        _ceilingVertices = new Vector3[path.Length];

    //        Vector3 vertexOffset = new Vector3(-path[0].position.x + 1, -path[0].position.y, -path[0].position.z);

    //        // Add vertex information to arrays
    //        for( int i=0; i<path.Length; ++i)
    //        {
    //            int offset = i * vertsInShape;
    //            for(int j=0; j<vertsInShape; ++j)
    //            {
    //                int id = offset + j;
    //                //_vertices[id] = path[i].position + new Vector3(shape.verts[j].x, shape.verts[j].y);
    //                _vertices[id] = path[i].LocalToWorld(shape.verts[j]) + vertexOffset;
    //                //_vertices[id] = path[i].WorldToLocal(shape.verts[j]);
    //                _normals[id] = path[i].rotation * shape.normals[j];//path[i].LocalToWorldDirection(shape.normals[j]);
    //                _uvs[id] = new Vector2(i / ((float)edgeLoops), shape.us[j]);
    //                if (j == vertsInShape - 1) _ceilingVertices[i] = _vertices[id];
    //            }
    //        }

    //        // Build triangles array
    //        int ti = 0;
    //        for(int i=0; i < segments; ++i)
    //        {
    //            int offset = i * vertsInShape;
    //            for(int j = 0; j < shape.lines.Length; j += 2)
    //            {
    //                int a = offset + shape.lines[j] + vertsInShape;
    //                int b = offset + shape.lines[j];
    //                int c = offset + shape.lines[j + 1];
    //                int d = offset + shape.lines[j + 1] + vertsInShape;
    //                _triangles[ti] = a; ++ti;
    //                _triangles[ti] = b; ++ti;
    //                _triangles[ti] = c; ++ti;
    //                _triangles[ti] = c; ++ti;
    //                _triangles[ti] = d; ++ti;
    //                _triangles[ti] = a; ++ti;
    //            }
    //        }

    //        mesh.Clear();
    //        mesh.vertices = _vertices;
    //        mesh.triangles = _triangles;
    //        mesh.normals = _normals;
    //        mesh.uv = _uvs;

    //        meshCollider.sharedMesh = mesh;
    //        OnMeshDraw.Invoke();
    //    }
    //    if (clearMesh)
    //    {
    //        mesh.Clear();
    //        clearMesh = false;
    //        OnMeshClear.Invoke();
    //    }
    //}

    public void DrawMesh()
    {
        var shape = new WallExtrudeShape(wallHeight);
        OrientedPoint[] path = GetPathFromSpline();
        int edgeLoops = path.Length;
        int vertsInShape = shape.verts.Length;
        int vertCount = vertsInShape * edgeLoops;
        int triCount = shape.lines.Length * segments;
        int triIndexCount = triCount * 3;

        _triangles = new int[triIndexCount];
        _vertices = new Vector3[vertCount];
        _normals = new Vector3[vertCount];
        _uvs = new Vector2[vertCount];

        _ceilingVertices = new Vector3[path.Length];

        Vector3 vertexOffset = new Vector3(-path[0].position.x + 1, -path[0].position.y, -path[0].position.z);

        // Add vertex information to arrays
        for (int i = 0; i < path.Length; ++i)
        {
            int offset = i * vertsInShape;
            for (int j = 0; j < vertsInShape; ++j)
            {
                int id = offset + j;
                //_vertices[id] = path[i].position + new Vector3(shape.verts[j].x, shape.verts[j].y);
                _vertices[id] = path[i].LocalToWorld(shape.verts[j]) + vertexOffset;
                //_vertices[id] = path[i].WorldToLocal(shape.verts[j]);
                _normals[id] = path[i].rotation * shape.normals[j];//path[i].LocalToWorldDirection(shape.normals[j]);
                _uvs[id] = new Vector2(i / ((float)edgeLoops), shape.us[j]);
                if (j == vertsInShape - 1) _ceilingVertices[i] = _vertices[id];
            }
        }

        // Build triangles array
        int ti = 0;
        for (int i = 0; i < segments; ++i)
        {
            int offset = i * vertsInShape;
            for (int j = 0; j < shape.lines.Length; j += 2)
            {
                int a = offset + shape.lines[j] + vertsInShape;
                int b = offset + shape.lines[j];
                int c = offset + shape.lines[j + 1];
                int d = offset + shape.lines[j + 1] + vertsInShape;
                _triangles[ti] = a; ++ti;
                _triangles[ti] = b; ++ti;
                _triangles[ti] = c; ++ti;
                _triangles[ti] = c; ++ti;
                _triangles[ti] = d; ++ti;
                _triangles[ti] = a; ++ti;
            }
        }

        if (reverseNormals)
        {
            for (int i = 0; i < _triangles.Length; i += 3)
            {
                int temp = _triangles[i + 0];
                _triangles[i + 0] = _triangles[i + 1];
                _triangles[i + 1] = temp;
            }
        }

        mesh.Clear();
        mesh.vertices = _vertices;
        mesh.triangles = _triangles;
        mesh.normals = _normals;
        mesh.uv = _uvs;

        meshCollider.sharedMesh = mesh;
    }

    public void ClearMesh()
    {
        mesh.Clear();
        meshCollider.sharedMesh = mesh;
    }

    private OrientedPoint[] GetPathFromSpline()
    {
        if (_spline == null) _spline = GetComponent<BezierSpline>();
        float dt = 1f / segments;
        OrientedPoint[] path = new OrientedPoint[segments + 1];
        for (int i = 0; i < segments + 1; ++i)
        {
            var t = i * dt;
            var point = _spline.GetPoint(t);
            path[i] = new OrientedPoint(point, GetOrientation3D(t, Vector3.up));
        }
        return path;
    }

    private Quaternion GetOrientation2D( float t)
    {
        Vector3 tng = GetTangent(t);
        Vector3 nrm = GetNormal2D(t);
        return Quaternion.LookRotation(tng, nrm);
    }

    private Quaternion GetOrientation3D( float t, Vector3 up)
    {
        Vector3 tng = GetTangent(t);
        Vector3 nrm = GetNormal3D(t,up);
        return Quaternion.LookRotation(tng,nrm);
    }

    private Vector3 GetNormal2D(float t)
    {
        Vector3 tng = GetTangent(t);
        return new Vector3(-tng.y, tng.x, 0.0f);
    }

    private Vector3 GetNormal3D( float t, Vector3 up )
    {
        Vector3 tng = GetTangent(t);
        Vector3 binormal = Vector3.Cross(up, tng).normalized;
        return Vector3.Cross(tng, binormal);
    }

    private Vector3 GetTangent(float t)
    {
        return _spline.GetVelocity(t).normalized;
    }

}
