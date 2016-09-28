using UnityEngine;
using System.Collections;

public class DisableRotation : MonoBehaviour {

	private Vector3 _zeroVec;
	// Use this for initialization
	void Start () {
		_zeroVec = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(_zeroVec);
	}
}
