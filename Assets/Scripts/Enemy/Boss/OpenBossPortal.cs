using UnityEngine;
using System.Collections;

public class OpenBossPortal : MonoBehaviour {

	public GameObject portal;
	// Use this for initialization
	public void EnablePortal()
	{
		portal.SetActive (true);
	}
}
