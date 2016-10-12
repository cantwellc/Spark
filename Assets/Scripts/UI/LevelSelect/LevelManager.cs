using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour {
	[System.Serializable]
	public class Level
	{
		public string levelText;
		public int unlocked;
		public string sceneFileName;
		public bool isInteractable;

	}

	public List<Level> levelList;
	public Transform spacer;
	public GameObject buttonGUI;

	void Start () 
	{
		FillList ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FillList()
	{
		for (int i = 0; i < levelList.Count; i++)
		{
			GameObject btn = Instantiate (buttonGUI) as GameObject;
			LevelButton levelBtn = btn.GetComponent<LevelButton> ();
			levelBtn.levelText.text = levelList [i].levelText;
			btn.transform.SetParent (spacer, false);
			levelList [i].unlocked = 0;
			levelList [i].isInteractable = false;
			int unlockedStatus = PlayerPrefs.GetInt (levelList [i].levelText);
			if (unlockedStatus == 1)
			{
				levelList [i].unlocked = 1;
				levelList [i].isInteractable = true;
			} 
			levelBtn.unlocked = levelList [i].unlocked;
			Button btnComponent = btn.GetComponent<Button> ();
			btnComponent.interactable = levelList [i].isInteractable;
			string sceneFileName = levelList [i].sceneFileName;
			btnComponent.onClick.AddListener(()=>loadLevel(sceneFileName));
		}

		SaveAll ();
	}


	void loadLevel(string levelName)
	{
		SceneManager.LoadScene (levelName);
	}


	void SaveAll()
	{
		
		GameObject[] allButtons = GameObject.FindGameObjectsWithTag ("LevelButton");
		foreach (GameObject btn in allButtons)
		{
			LevelButton levelBtn = btn.GetComponent<LevelButton> ();
			PlayerPrefs.SetInt (levelBtn.levelText.text, 1);
			PlayerPrefs.Save ();

		}
	}
}
