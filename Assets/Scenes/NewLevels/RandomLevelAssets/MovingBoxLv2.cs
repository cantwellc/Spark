using UnityEngine;
using System.Collections;

public class MovingBoxLv2 : MonoBehaviour {

    private Vector3 targetPosition1, targetPosition2;
    private Vector3 velocity = Vector3.zero;
    private int target;

    private float tmr=0;

    // Use this for initialization
    void Start () {
        target = 1;
        targetPosition1 = transform.position - new Vector3(4.5f, 0.0f, 0.0f);
        targetPosition2 = transform.position + new Vector3(4.5f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update () {
        tmr += Time.deltaTime;
        if (target == 2)
        {
            //Debug.Log("moving to 2");
            if (tmr >= 2.0f)
            { target = 1; tmr = 0.0f;  Debug.Log("now target is 1"); }
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition2, ref velocity, 0.5f);
        }
        else if (target == 1)
        {
            //Debug.Log("moving to 1");
            if (tmr >= 2.0f)
            { target = 2; tmr = 0.0f; Debug.Log("now target is 2"); }
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition1, ref velocity, 0.5f);
        }
   }
}
