using UnityEngine;
using System.Collections;

public class LockRotateY : MonoBehaviour 
{
	void Update () 
	{
        transform.rotation = new Quaternion(0.0f, transform.rotation.y, 0.0f, transform.rotation.w);
	}
}
