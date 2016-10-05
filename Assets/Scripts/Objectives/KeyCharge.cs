using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyCharge : MonoBehaviour {

	public List<Renderer> keyLightRenderers;
	private float maxKeyChargeForLevel;
	private float neededKeyChargeForLevel;
	private float _lightCount;
	public float _totalCharge;
	private float _fullSingleLightCharge;
	public void addCharge(float charge)
	{
		_totalCharge +=charge;
		UpdateKeyLights ();
	}

	void UpdateKeyLights()
	{
		for (int i = 0; i < keyLightRenderers.Count; i++)
		{
			
			float diff = _totalCharge - (i * _fullSingleLightCharge);
			if (diff >= _fullSingleLightCharge)
			{
				keyLightRenderers [i].material.color = Color.yellow;
			} 
			else
			{
				keyLightRenderers [i].material.color = Color.gray;
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

		GameObject levelSpecificValues = GameObject.Find ("LevelSpecificValues");
		neededKeyChargeForLevel = levelSpecificValues.GetComponent<LevelSpecificValues> ().neededKeyChargeForLevel;
		maxKeyChargeForLevel = levelSpecificValues.GetComponent<LevelSpecificValues> ().maxKeyChargeForLevel;
		_totalCharge = 0;
		_fullSingleLightCharge = maxKeyChargeForLevel / keyLightRenderers.Count;
		UpdateKeyLights ();
	}

	public bool ChargedEnoughForPedestal()
	{
		if (_totalCharge >= neededKeyChargeForLevel)
		{
			return true;
		}
		return false;
	}
	

}
