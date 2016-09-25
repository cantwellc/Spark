using UnityEngine;
using System.Collections;

public class DamageTakenEffect : MonoBehaviour 
{

	public Renderer rendererOfObject;
	public GameObject hitParticleEffect;
	public float destroyHitEffectInSeconds;

	private Color _originalColor;

	public void TakeDamageEffect()
    {
		Debug.Log ("Take damage called");
		//Add a sleep to add some satisfaction when hitting
		System.Threading.Thread.Sleep(10);
		if (rendererOfObject != null)
		{
			rendererOfObject.material.color = Color.red;
			Invoke("returnToOriginalColor", 0.1f);
		}
		if (hitParticleEffect)
		{
			GameObject enemyHitEffect = Instantiate(hitParticleEffect, transform.position, transform.rotation) as GameObject;
			Destroy(enemyHitEffect, destroyHitEffectInSeconds);
		}
    }

	private void returnToOriginalColor()
	{
		rendererOfObject.material.color = _originalColor;
	}
}
