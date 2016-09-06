using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamewon : MonoBehaviour {

	public Text FinishText;

	void OnTriggerEnter()
	{
		FinishText.text = "You have passed the level!";
	}


}
