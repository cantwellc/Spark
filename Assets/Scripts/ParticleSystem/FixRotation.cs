using UnityEngine;
using System.Collections;

public class FixRotation : MonoBehaviour {

	private Vector3 _vec;
	public float x;
	public float y;
	public float z;
	// Use this for initialization
	void Start () {
		_vec = new Vector3 (x, y, z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localRotation = Quaternion.Euler(_vec);
	}
}
