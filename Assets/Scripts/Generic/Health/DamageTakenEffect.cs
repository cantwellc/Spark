using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamageTakenEffect : MonoBehaviour 
{

	public List<Renderer> renderersOfObject;
	public GameObject hitParticleEffect;
	public float destroyHitEffectInSeconds;

	private List<Color> _originalColors;


	public void Start()
	{
        _originalColors = new List<Color>();
        foreach(Renderer renderer in renderersOfObject)
        {
            _originalColors.Add(renderer.material.color);
        }
		    
	}

	public void TakeDamageEffect()
    {
		
		//Add a sleep to add some satisfaction when hitting
		System.Threading.Thread.Sleep(10);
		if (renderersOfObject != null)
		{
            foreach(Renderer renderer in renderersOfObject)
            {
                renderer.material.color = Color.red;
            }
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
        for(int i = 0; i < renderersOfObject.Count; i++)
        {
            renderersOfObject[i].material.color = _originalColors[i];
        }
		
	}
}
