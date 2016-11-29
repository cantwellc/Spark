using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class FadeInAndOut : MonoBehaviour {

	public float fadeInSeconds = 5.0f;
	public float fadeOutSeconds = 1.0f;
	public float intervalBetween = 1.0f;
	public Text text;


	// Use this for initialization
	void Start () 
	{
		text.canvasRenderer.SetAlpha( 0.01f );
		//Color color = text.GetComponent<Text> ().color;
		//Color newColor = new Color (1, 1, 1, 0);
		//text.GetComponent<Text> ().color = newColor;
		startFadeIn ();
	}
	
	// Update is called once per frame


	void startFadeOut()
	{
		text.CrossFadeAlpha(0.0f, fadeOutSeconds, false);
	}

	void startFadeIn()
	{
		text.CrossFadeAlpha(1.0f, fadeInSeconds, false);
		Invoke ("startFadeOut", intervalBetween);
	}


}
