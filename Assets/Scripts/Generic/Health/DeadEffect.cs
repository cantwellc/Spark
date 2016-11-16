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
			//AudioManager.instance.Play ("droneExplode", gameObject);
			Vector3 VFXInstantiation = new Vector3(transform.position.x,transform.position.y+1,transform.position.z);
			GameObject deadEffect = Instantiate(enemyDeadEffect, VFXInstantiation, transform.rotation) as GameObject;
			Destroy(deadEffect, destroyDeadEffectInSeconds);
		}
	}

}
