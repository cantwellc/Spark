using UnityEngine;
using System.Collections;

public class DestroyAsteroid : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Destruction()
    {
        gameObject.SetActive(false);
    }
}
