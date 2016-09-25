using UnityEngine;
using System.Collections;

public class DeadEffect : MonoBehaviour 
{
	public GameObject enemyDeadEffect;
	public float destroyDeadEffectInSeconds;
	public void DeadEffects()
	{
		if(enemyDeadEffect)
		{
			GameObject deadEffect = Instantiate(enemyDeadEffect, transform.position, transform.rotation) as GameObject;
			Destroy(deadEffect, destroyDeadEffectInSeconds);
		}
	}

}
