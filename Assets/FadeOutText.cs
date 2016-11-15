using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FadeOutText : MonoBehaviour {
	public float fadeSpeed = 5.0f;
	public Text text ;

	// Use this for initialization
	void Start () {
		text.CrossFadeAlpha(0.0f, 1.5f, false);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		

	
	}
}
