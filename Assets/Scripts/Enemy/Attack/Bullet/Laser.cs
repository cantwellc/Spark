using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    public LineRenderer line;
    public Transform laserStartPoint;
    public float range;
    public float damagePerSec;

    bool _activated;

	// Use this for initialization
	void Start () {
        _activated = false;
	}

    public void activateLaser()
    {
        _activated = true;
        line.enabled = true;
    }

    public void stopLaser()
    {
        _activated = false;
        line.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	    if(_activated)
        {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(laserStartPoint.transform.position, transform.forward,  range);
            //Physics.Raycast(laserStartPoint.transform.position, transform.forward, out hit, range);
            int hitOffset = -1;
            float closesDist = range;
            for(int a=0;a!=hits.Length;++a)
            {
                if (hits[a].collider.tag == "ExtraCollider") continue;
                if((laserStartPoint.transform.position-hits[a].point).magnitude < closesDist)
                {
                    closesDist = (laserStartPoint.transform.position - hits[a].point).magnitude;
                    hitOffset = a;
                }
            }
            if(hitOffset != -1 && hitOffset < hits.Length)
            {

                line.SetPosition(0, laserStartPoint.transform.position);
                line.SetPosition(1, hits[hitOffset].point);
                if (hits[hitOffset].collider.tag == "Character")
                {
                    hits[hitOffset].collider.GetComponent<Health>().TakeDamage(damagePerSec * Time.deltaTime);

                }
            }
            else
            {
                line.SetPosition(0, laserStartPoint.transform.position);
                line.SetPosition(1, laserStartPoint.transform.position + transform.forward * range);
            }
        }
	}
}
