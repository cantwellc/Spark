using UnityEngine;
using System.Collections;

public class LockRotateAxis : MonoBehaviour {
    public float x;
    public float y;
    public float z;

	// Update is called once per frame
	void Update () {
        if (x == 0)
            transform.rotation = new Quaternion(x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        if (y == 0)
            transform.rotation = new Quaternion(transform.rotation.x, y, transform.rotation.z, transform.rotation.w);
        if (z == 0)
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, z, transform.rotation.w);
    }
}
