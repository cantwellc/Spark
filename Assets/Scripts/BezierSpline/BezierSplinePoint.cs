using UnityEngine;
using System.Collections;

public class BezierSplinePoint : MonoBehaviour {

    [SerializeField]
    private Vector3 _controlPoint1Relative;
    public Vector3 controlPoint1
    {
        get
        {
            return transform.position + _controlPoint1Relative;
        }
        set
        {
            _controlPoint1Relative = value - transform.position;
        }
    }

    [SerializeField]
    private Vector3 _controlPoint2Relative;
    public Vector3 controlPoint2
    {
        get
        {
            return transform.position + _controlPoint2Relative;
        }
        set
        {
            _controlPoint2Relative = value - transform.position;
        }
    }

    public Vector3 position
    {
        get
        {
            return transform.position;
        }
    }

    private Vector3[] _points;
    public Vector3[] points
    {
        get
        {
            return new Vector3[] { controlPoint1, transform.position, controlPoint2 };
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.25f);
    }

}
