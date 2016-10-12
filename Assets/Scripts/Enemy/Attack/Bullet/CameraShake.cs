//From https://gist.github.com/ftvs/5822103
using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration;// = 0f;
	private float _shakeDuration = 0f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	private bool _shaking = false;

	Vector3 originalPos;

	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
		_shakeDuration = shakeDuration;
	}

	void OnEnable()
	{
		
	}

	void Update()
	{
		originalPos = camTransform.localPosition;
		if (_shaking)
		{

			if (_shakeDuration > 0)
			{
				camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
                var follow = GetComponent<CameraFollow>();
                if(follow != null) follow.EnableShaking ();
				_shakeDuration -= Time.deltaTime * decreaseFactor;
			} 
			else
			{
                var follow = GetComponent<CameraFollow>();
                if (follow != null) follow.DisableShaking();
				_shaking = false;
				_shakeDuration = shakeDuration;
				camTransform.localPosition = originalPos;
			}
		}

	}
	public void Shake()
	{
		_shaking = true;
	}




}