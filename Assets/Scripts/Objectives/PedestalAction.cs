using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PedestalAction : MonoBehaviour {

	public GameObject _portal;
	public UnityEvent onOpeningPortal;
	public bool startAction;
	// Use this for initialization

	public void Run()
	{
		onOpeningPortal.Invoke ();
		startAction = true;
		GetComponent<Renderer> ().material.color = Color.green;
		SpawnPortal ();

	}
	void SpawnPortal()
	{
		_portal.SetActive (true);
	}
}

