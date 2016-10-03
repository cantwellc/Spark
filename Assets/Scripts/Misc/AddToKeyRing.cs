using UnityEngine;
using System.Collections;

public class AddToKeyRing : MonoBehaviour {

	public GameObject keyRing;
	public float speed;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		keyRing.GetComponent<KeyCharge> ().addCharge (speed * Time.deltaTime);
	}
}
