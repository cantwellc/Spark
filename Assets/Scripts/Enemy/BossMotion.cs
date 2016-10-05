using UnityEngine;
using System;
using System.Collections;


public class BossMotion : MonoBehaviour {

    public GameObject target1, target2, target3, target4;
    public float timeToReachNextTarget;
    public float timeToStayAtOneTarget;
    public float staartMovingAtHealth;

    private Vector3 velocity = Vector3.zero;
    private int target;
    private float tmr = 0;
    private System.Random r;
    
	// Use this for initialization
	void Start () {
        target = 1;
        r = new System.Random();
	}
	
	// Update is called once per frame
	void Update () {
        tmr += Time.deltaTime;
        Health h = gameObject.GetComponent<Health>();
        if (h.HealthPercent < staartMovingAtHealth)
        {
            if (target == 1)
            {
                //Debug.Log("moving to 1");
                if (tmr >= timeToStayAtOneTarget)
                { target = r.Next(1, 4); tmr = 0.0f; }
                transform.position = Vector3.SmoothDamp(transform.position, target1.transform.position, ref velocity, timeToReachNextTarget);
            }
            
            else if (target == 2)
            {
                //Debug.Log("moving to 2");
                if (tmr >= timeToStayAtOneTarget)
                { target = r.Next(1, 4); tmr = 0.0f; }
                transform.position = Vector3.SmoothDamp(transform.position, target2.transform.position, ref velocity, timeToReachNextTarget);
            }

            else if (target == 3)
            {
                //Debug.Log("moving to 2");
                if (tmr >= timeToStayAtOneTarget)
                { target = r.Next(1, 4); tmr = 0.0f; }
                transform.position = Vector3.SmoothDamp(transform.position, target3.transform.position, ref velocity, timeToReachNextTarget);
            }

            else if (target == 4)
            {
                //Debug.Log("moving to 2");
                if (tmr >= timeToStayAtOneTarget)
                { target = r.Next(1, 4); tmr = 0.0f; }
                transform.position = Vector3.SmoothDamp(transform.position, target4.transform.position, ref velocity, timeToReachNextTarget);
            }

        }
    }
}
