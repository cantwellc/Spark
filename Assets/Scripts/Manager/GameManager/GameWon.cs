using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour 
{

	public Text finishText;
	private bool _finishCheck = false;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Character") 
		{
		//	finishText.text = "You have passed the level!" +
		//	"\n" +
		//	"Press R to restart the level.";
			_finishCheck = true;
		}

	}
	void Update()
	{

		if (Input.GetKeyDown (KeyCode.R))
		{
			if (_finishCheck)
			{
				//finishText.text = "";
				_finishCheck = false;

			} 
			SceneManager.LoadScene ("DemoLevel");
		} 
	}


}
