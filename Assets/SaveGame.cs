using UnityEngine;
using System.Collections;

public class SaveGame : MonoBehaviour {

	public string LevelSceneName;
	// Use this for initialization
	void Start () 
	{
		PlayerPrefs.SetString ("LastLevel", LevelSceneName);
	}
	

}
