using UnityEngine;
using System.Collections;
using System;

public class TrackCharacter : MonoBehaviour {
    public float trackingSpeed;

    private Transform _character;

	// Update is called once per frame
	void Update () {
        if (_character == null) SetCharacter();
        if (_character == null) return;
        var direction = (_character.position - transform.position).normalized;
        direction = new Vector3(direction.x, 0.0f, direction.z).normalized;
        var lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * trackingSpeed);
	}

    private void SetCharacter()
    {
        if (Character.current == null) return;
        _character = Character.current.transform;
    }
}
