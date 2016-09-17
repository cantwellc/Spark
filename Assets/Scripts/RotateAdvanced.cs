using UnityEngine;
using System.Collections;

public class RotateAdvanced : MonoBehaviour {

    public float XRotateSpeed = 10.0f;
    public float YRotateSpeed = 10.0f;
    public float ZRotateSpeed = 10.0f;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(XRotateSpeed, Time.deltaTime * YRotateSpeed, ZRotateSpeed);
	}
}
