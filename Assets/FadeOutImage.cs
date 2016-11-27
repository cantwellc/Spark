using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FadeOutImage : MonoBehaviour {
	public float fadeSpeed = 5.0f;
	public Image image ;

	// Use this for initialization
	void Start () {
		image.CrossFadeAlpha(0.0f, 0.5f, false);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		

	
	}
}
