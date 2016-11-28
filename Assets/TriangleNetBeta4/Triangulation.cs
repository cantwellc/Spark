using UnityEngine;
using System.Collections.Generic;
using TriangleNet.Geometry;
using System.Linq;

public class Triangulation
{

    public static bool Triangulate(List<Vector2> points, List<List<Vector2>> holes, out List<int> outIndices, out List<Vector3> outVertices, float yOffset = 0.0f)
    {
        outVertices = new List<Vector3>();
        outIndices = new List<int>();

        Polygon poly = new Polygon();
        if (points[points.Count - 1] == points[0]) points = points.Take(points.Count - 1).ToList();

        // Points and Segments
        for (int i = 0; i < points.Count; ++i)
        {
            poly.Add(new Vertex(points[i].x, points[i].y));
            if (i == points.Count - 1)
            {
                poly.Add(new Segment(new Vertex(points[i].x, points[i].y), new Vertex(points[0].x, points[0].y)));
            }
            else
            {
                poly.Add(new Segment(new Vertex(points[i].x, points[i].y), new Vertex(points[i + 1].x, points[i + 1].y)));
            }
        }

        if (holes != null)
        {
            for (int i = 0; i < holes.Count; ++i)
            {
                var vertices = new List<Vertex>();
                for (int j = 0; j < holes[i].Count; ++j)
                {
                    vertices.Add(new Vertex(holes[i][j].x, holes[i][j].y));
                }
                poly.Add(new Contour(vertices), true);
            }
        }

        var mesh = poly.Triangulate();

        foreach (var t in mesh.Triangles)
        {
            for (int j = 2; j >= 0; --j)
            {
                bool found = false;
                for (int k = 0; k < outVertices.Count; ++k)
                {
                    if ((outVertices[k].x == t.GetVertex(j).X) && (outVertices[k].z == t.GetVertex(j).Y))
                    {
                        outIndices.Add(k);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    outVertices.Add(new Vector3((float)t.GetVertex(j).X, yOffset, (float)t.GetVertex(j).Y));
                    outIndices.Add(outVertices.Count - 1);
                }
            }
        }
        return true;
    }

    public static bool Triangulate(List<Vector3> points, List<List<Vector2>> holes, out List<int> outIndices, out List<Vector3> outVertices, float yOffset = 0.0f)
    {
        List<Vector2> points2 = new List<Vector2>();
        foreach (var point in points)
        {
            points2.Add(new Vector2(point.x, point.z));
        }
        return Triangulate(points2, holes, out outIndices, out outVertices, yOffset);
    }
}