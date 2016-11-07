using UnityEngine;
using System.Collections;

public class HitEffectWithHealth : MonoBehaviour {

	public Health health;
	public GameObject VFX;
	private bool VFX_enabled = false;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( !VFX_enabled && health.HealthPercent < 0.7 )
		{
			VFX.SetActive (true);
			VFX_enabled = true;
		}
	}
}
