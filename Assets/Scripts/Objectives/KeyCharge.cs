using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyCharge : MonoBehaviour {

	public List<Renderer> keyLightRenderers;
	private float _maxKeyChargeForLevel;
	private float _neededKeyChargeForLevel;
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
		_neededKeyChargeForLevel = levelSpecificValues.GetComponent<LevelSpecificValues> ().neededKeyChargeForLevel;
		_maxKeyChargeForLevel = levelSpecificValues.GetComponent<LevelSpecificValues> ().maxKeyChargeForLevel;
		_totalCharge = 0;
		_fullSingleLightCharge = _maxKeyChargeForLevel / keyLightRenderers.Count;
		UpdateKeyLights ();
	}

	public bool ChargedEnoughForPedestal()
	{
		if (_totalCharge >= _neededKeyChargeForLevel)
		{
			return true;
		}
		return false;
	}
	public string GetChargeStatus()
	{
		
		int foundKeyCount = Mathf.CeilToInt (_totalCharge/50);
		if (_totalCharge != 0)
		{
			return foundKeyCount.ToString () + " / " + (_maxKeyChargeForLevel / 50).ToString ();
		}
		return "0" + " / " + (_maxKeyChargeForLevel / 50).ToString ();
	}
	

}
