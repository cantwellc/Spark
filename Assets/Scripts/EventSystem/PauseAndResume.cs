using UnityEngine;
using System.Collections;

public class PauseAndResume : MonoBehaviour {


    private Rigidbody _rigidBody;
    private Vector3 _velocity;
    private Vector3 _anglerVelocity;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void OnEnable()
    {
        EventManager.StartListening(EventManager.Events.PAUSE_GAME, OnPause);
        EventManager.StartListening(EventManager.Events.RESUME_GAME, OnResume);
    }

    void Ondisable()
    {
        EventManager.StopListening(EventManager.Events.PAUSE_GAME, OnPause);
        EventManager.StopListening(EventManager.Events.RESUME_GAME, OnResume);
    }

    void OnPause()
    {
        _velocity = _rigidBody.velocity;
        _anglerVelocity = _rigidBody.angularVelocity;
        _rigidBody.Sleep();
    }

    void OnResume()
    {
        _rigidBody.WakeUp();
        _rigidBody.velocity = _velocity;
        _rigidBody.angularVelocity = _anglerVelocity;
    }
}
