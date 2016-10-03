using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyCharge : MonoBehaviour {

	public List<Renderer> keyLightRenderers;
	public float maxCharge;
	public float minChargeNeededToOpenPortal;
	private float _lightCount;
	public float _totalCharge;
	private float _fullSingleLightCharge;
	public void addCharge(float charge)
	{
		_totalCharge +=charge;
		updateKeyLights ();
	}

	void updateKeyLights()
	{
		for (int i = 0; i < keyLightRenderers.Count; i++)
		{
			
			float diff = _totalCharge - (i * _fullSingleLightCharge);
			if (diff >= _fullSingleLightCharge)
			{
				keyLightRenderers [i].material.color = Color.green;
			} 
			else
			{
				keyLightRenderers [i].material.color = Color.red;
			}
			/*float ratio = diff / (i * _fullSingleLightCharge);
			float r = 1.0f * (1 - ratio);
			float g = 0.1f * (1 + ratio);
			Color color = new Color (r ,g,0.0f);
			keyLightRenderers [i].material.color = color;*/
		}
	}
		
	void Start () 
	{
		_totalCharge = 0;
		_fullSingleLightCharge = maxCharge / keyLightRenderers.Count;
		updateKeyLights ();
	}
	

}
