using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class SingleEventTrigger : MonoBehaviour {

	public UnityEvent triggerEnter;
	public UnityEvent triggerStay;
	public UnityEvent triggerExit;
	private bool _collided = false;
	public bool disableOnExit = false;

	public List<string> validTargetTags;
	// Use this for initialization
	void Start() {

	}

	void OnTriggerEnter(Collider col)
	{
		if (_collided) return;
		if (validTargetTags == null) return;
		if (!validTargetTags.Contains(col.gameObject.tag)) return;
		triggerEnter.Invoke();
		_collided = true;
	}

	void OnTriggerStay(Collider col)
	{
		if (validTargetTags == null) return;
		if (!validTargetTags.Contains(col.gameObject.tag)) return;
		triggerStay.Invoke();
	}

	void OnTriggerExit(Collider col)
	{
		if (validTargetTags == null) return;
		if (!validTargetTags.Contains(col.gameObject.tag)) return;
		triggerExit.Invoke();
		if (disableOnExit)
		{
			gameObject.SetActive (false);
		}
	}
}
