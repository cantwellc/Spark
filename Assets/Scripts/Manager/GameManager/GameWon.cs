using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour 
{

	public Text finishText;
	public string nextScene;
	private bool _finishCheck = false;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Character") 
		{
			_finishCheck = true;
			SceneManager.LoadScene(nextScene);
		}

	}
	void Update()
	{

		//if (Input.GetKeyDown (KeyCode.R))
		//{
		//	if (_finishCheck)
		//	{
		//		_finishCheck = false;
		//	} 
		//	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		//} 
	}

    bool getFinish()
    {
        return _finishCheck;
    }
}
