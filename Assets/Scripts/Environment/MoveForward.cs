using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class MoveForward : MonoBehaviour {
    public UnityEvent OnStartMoving;
    public UnityEvent OnStopMoving;

    public float speed;

    public bool doMove = false;

    private Transform _transform;

    void Awake()
    {
        _transform = GetComponent<Transform>();
    }

	
	// Update is called once per frame
	void Update () 
	{
        if (!doMove) return;
        var step = speed * Time.deltaTime;
        var forward = transform.worldToLocalMatrix.MultiplyVector(transform.forward);
        _transform.Translate(forward * step);
	}

	public void StartMoving()
	{
		doMove = true;
        OnStartMoving.Invoke();
	}
	public void StopMoving()
	{
		doMove = false;
        OnStopMoving.Invoke();
	}

    public void SlamShut()
    {
        speed = 20.0f;
    }
	public void openSlowly()
	{
	
	}

}
