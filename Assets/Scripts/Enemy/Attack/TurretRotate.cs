using UnityEngine;
using System.Collections;

public class TurretRotate : MonoBehaviour {

    public enum RotateType
    {
        Spiral,
        AlternateDirection
    }

    public RotateType rotateType;

    public float turnSpeed;
    public float alternateShootingDirInDegree1;
    public float alternateShootingDirInDegree2;
    public float alternateStayingTime;   //Time to shoot in each direction

    int _alternateShootingDir = 0;
    float _alternateShootingTimeRemain = 0;

    bool _isFinding;

	void Start () {
        _isFinding = true;
	}

    void StartShooting()
    {
        _isFinding = false;
    }
    void StopShooting()
    {
        _isFinding = true;
    }

    public void EndFinding()
    {

    }
	
	// Update is called once per frame
	void Update () {
	    if(_isFinding)
        {
            if(RotateType.AlternateDirection == rotateType)
            {
                if(_alternateShootingTimeRemain <= 0)
                    alternateTurn();
                _alternateShootingTimeRemain -= Time.deltaTime;
            } else
            {
                transform.Rotate(0, turnSpeed, 0);
            }
        }
	}

    void alternateTurn()
    {
        if (_alternateShootingDir == 0)
        {
            Quaternion dest = Quaternion.Euler(0, alternateShootingDirInDegree2, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, dest, Time.deltaTime * turnSpeed / Quaternion.Angle(transform.rotation, dest));
            if (Quaternion.Angle(transform.rotation, dest) <= 1)
            {
                _alternateShootingDir = 1;
                _alternateShootingTimeRemain = alternateStayingTime;
            }
        }
        else
        {
            Quaternion dest = Quaternion.Euler(0, alternateShootingDirInDegree1, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, dest, Time.deltaTime * turnSpeed / Quaternion.Angle(transform.rotation, dest));
            if (Quaternion.Angle(transform.rotation, dest) <= 1)
            {
                _alternateShootingDir = 0;
                _alternateShootingTimeRemain = alternateStayingTime;
            }
        }

    }
}
