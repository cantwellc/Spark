using UnityEngine;
using System.Collections;

public class CharacterBulletSelfRotation : MonoBehaviour {

    public float rotationSpeed = 10;

	void Update ()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
	}
}
