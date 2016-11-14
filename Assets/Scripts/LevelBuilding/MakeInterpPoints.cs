using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MakeInterpPoints : MonoBehaviour {

    public bool toInterp = false;
    public bool toClearGizmos = false;
    public int firstPoint;
    public int lastPoint;
    public float interpDist;
    public float interpCurveWeight;
    public GameObject childPrefab;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(toInterp)
        {
            toInterp = false;
            int last = lastPoint;
            for(int a=firstPoint; a<=last-1;++a)
            {
                Vector3 cur = transform.GetChild(a).position;
                Vector3 next = transform.GetChild(a + 1).position;
                Vector3 afterNext;
                if(a != last-1) 
                    afterNext = transform.GetChild(a + 2).position;
                else 
                    afterNext = transform.GetChild(a - 1).position;
                float dist = Vector3.Distance(cur, next);
                int interpCount = (int)(dist/interpDist);
                Vector3 dir = (next - cur).normalized;
                Vector3 vertical = Vector3.Cross(dir, Vector3.up).normalized;
                Vector3 afterD = afterNext - cur;
                //if (a == last - 1) afterD = -afterD;
                if (Vector3.Dot(vertical, afterD) > 0) vertical = -vertical;
                for(int b=1;b<=interpCount;++b)
                {
                    float mu = (float)b / (float)(interpCount+1);
                    float mu2 = ( Mathf.Sin(mu * Mathf.PI)) / 2.0f;
                    Vector3 pos = cur * (1 - mu) + next * mu;// + vertical*(Mathf.Sin(mu * Mathf.PI) );
                    Vector3 afterDir = (afterNext - pos);
                    if (a == lastPoint - 1) afterDir = -afterDir;
                    Vector3 offset = vertical * mu2;//Vector3.Dot(afterDir, dir) * interpCurveWeight;
                    offset = -offset * Vector3.Dot(afterD.normalized, vertical) * Vector3.Distance(next,cur)* interpCurveWeight;
                    pos += offset;

                    GameObject obj = (GameObject)Instantiate(childPrefab);
                    obj.transform.position = pos;
                    obj.transform.parent = transform;
                    obj.transform.SetSiblingIndex(a+b);
                }
                a += interpCount;
                last += interpCount;
            }
        }
        if(toClearGizmos)
        {
            toClearGizmos = false;
            for (int i = 0; i != transform.childCount; ++i)
            {
                if(transform.GetChild(i).gameObject.name == "CubeGizmos(Clone)")
                {
                    DestroyImmediate(transform.GetChild(i).gameObject);
                    i--;
                }
            }
        } 
	}
}
