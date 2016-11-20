using UnityEngine;
using System.Collections;

public class RotateAroundAxis : MonoBehaviour {
    public enum RotationAxis
    {
        x,y,z
    }
    public RotationAxis axis;
    public float rotateSpeed;
	
	// Update is called once per frame
	void Update () {
        float rotation = Time.deltaTime * rotateSpeed;
        float x = axis == RotationAxis.x ? rotation : 0.0f;
        float y = axis == RotationAxis.y ? rotation : 0.0f;
        float z = axis == RotationAxis.z ? rotation : 0.0f;
        transform.Rotate(new Vector3(x, y, z));
    }
}
