using UnityEngine;
using System.Collections;

public class PedestalAction : MonoBehaviour {

	public GameObject _portal;
	public bool startAction;
	// Use this for initialization

	public void Run()
	{
		startAction = true;
		GetComponent<Renderer> ().material.color = Color.green;
		SpawnPortal ();

	}
	void SpawnPortal()
	{
		_portal.SetActive (true);
	}
}

