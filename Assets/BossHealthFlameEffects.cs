using UnityEngine;
using System.Collections;

public class BossHealthFlameEffects : MonoBehaviour {

	public Health health;
	public ParticleSystem fireEffect_1;
	public ParticleSystem fireEffect_2;
	public ParticleSystem fireEffect_3;
	public bool VFX_1_enabled = false;
	public bool VFX_2_enabled = false;
	public bool VFX_3_enabled = false;


	void Awake()
	{
		
		
	}


	void Update () 
	{

		if (health.HealthPercent < 0.1)
		{
			if (!VFX_3_enabled)
			{
				VFX_3_enabled = true;

				fireEffect_3.Play ();
			}
		}

		else if (health.HealthPercent < 0.4)
		{
			if (!VFX_2_enabled)
			{
				VFX_2_enabled = true;
				fireEffect_2.Play ();
			}
		}

		else if (health.HealthPercent < 0.7)
		{
			if (!VFX_1_enabled)
			{
				fireEffect_1.Play ();
				VFX_1_enabled = true;

			}
		}




	}
}
