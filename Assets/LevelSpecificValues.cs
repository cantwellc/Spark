using UnityEngine;
using System.Collections;

public class LevelSpecificValues : MonoBehaviour {

	public float neededKeyChargeForLevel;
	public float maxKeyChargeForLevel;

	// Use this for initialization
	void Start () 
	{
		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
		for (int i = 0; i < allObjects.Length; i++)
		{
			if (allObjects[i].GetComponent<Rigidbody>()!=null)
			{
				allObjects[i].AddComponent<PauseAndResume>();
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
