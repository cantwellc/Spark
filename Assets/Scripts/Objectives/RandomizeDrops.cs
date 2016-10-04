using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomizeDrops : MonoBehaviour {

	public int dropAmount;
	void Start () 
	{
		List<GameObject> toRandomize = new List<GameObject> ();
		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
		foreach (GameObject gameObject in allObjects)
		{
			if (gameObject.GetComponent<Turret> () != null)
			{
				toRandomize.Add (gameObject);
			}
		}
		if (dropAmount > toRandomize.Count)
		{
			Debug.LogError("You want level to have "+ dropAmount+ " of keys " +" but the level only has" + toRandomize.Count);
		}
		ShuffleGameObjects(ref toRandomize);
		int currentDropAmount = toRandomize.Count;
		for (int i = 0; i < toRandomize.Count; i++)
		{
			toRandomize [i].GetComponent<DropKeyCharger> ().dropKey = false;
			currentDropAmount--;
			if (currentDropAmount == dropAmount)
			{
				break;
			}

		}


	}

	void ShuffleGameObjects( ref List<GameObject> gameObjects)
	{
		for (int i = gameObjects.Count-1; i >= 0; i--)
		{
			 int r = Random.Range (0, gameObjects.Count);
			 GameObject temp = gameObjects [r];
			 gameObjects [r] = gameObjects [i];
			 gameObjects [i] = temp;
		}
	}

}
