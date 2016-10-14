using UnityEngine;
using System.Collections;

public class increaseWallSpeed : MonoBehaviour {

    public Crush cWall;

	void OnTriggerEnter()
    {
        cWall.speed *= 3;
    }
}
