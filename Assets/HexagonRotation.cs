using UnityEngine;
using System.Collections;

public class HexagonRotation : MonoBehaviour {
    public float x;
    public float z;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(new Vector3(x,0, z),new Vector3(0,1,0), 5 * Time.deltaTime);
    }
}
