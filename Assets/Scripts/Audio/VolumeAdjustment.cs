using UnityEngine;
using System.Collections;

public class VolumeAdjustment : MonoBehaviour {
	
	public AudioSource musicObject;


	void Update () 
	{
		if(Input.GetKey(KeyCode.UpArrow))
		{
			if(musicObject.volume < 1.0f)
			{
				musicObject.volume += 0.5f*Time.deltaTime;
			}
		}
		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			if (musicObject.volume > 0.0f) 
			{
				musicObject.volume -=0.5f*Time.deltaTime;
			}
		}
		if (Input.GetKeyDown (KeyCode.M))
		{
			if (musicObject.volume != 0.0f)
			{
				musicObject.volume = 0.0f;
			} 
			else
			{
				musicObject.volume = 0.5f;
			}
		}
			
	}
}
