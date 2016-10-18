using UnityEngine;
using System.Collections.Generic;

public class SetMoveForwardSpeed : MonoBehaviour {

    public float speed;
    public List<MoveForward> movingObjects;

	// Use this for initialization
	void Start () {
	    foreach(var obj in movingObjects)
        {
            obj.speed = speed;
        }
	}
}
