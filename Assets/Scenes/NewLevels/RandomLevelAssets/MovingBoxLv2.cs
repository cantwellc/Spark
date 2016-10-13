using UnityEngine;
using System.Collections;

public class MovingBoxLv2 : MonoBehaviour {

    public GameObject target1, target2;
    public float inTime;
    
    private Vector3 velocity = Vector3.zero;
    private int target;

    private float tmr=0;

    // Use this for initialization
    void Start () {
        target = 1;
    }

    // Update is called once per frame
    void Update () {
        tmr += Time.deltaTime;
        if (target == 2 && target2 != null)
        {
            //Debug.Log("moving to 2");
            if (tmr >= 2.0f)
            { target = 1; tmr = 0.0f;  Debug.Log("now target is 1"); }
            transform.position = Vector3.SmoothDamp(transform.position, target2.transform.position, ref velocity, inTime);
        }
        else if (target == 1 && target1 != null)
        {
            //Debug.Log("moving to 1");
            if (tmr >= 2.0f)
            { target = 2; tmr = 0.0f; Debug.Log("now target is 2"); }
            transform.position = Vector3.SmoothDamp(transform.position, target1.transform.position, ref velocity, inTime);
        }
   }
}
