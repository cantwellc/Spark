using UnityEngine;
using System.Collections;

public class Blackhole : MonoBehaviour {

    public GameObject enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!enemy.activeSelf)
        {
            GetComponent<TextMesh>().text = "BLACKHOLE!";
            GetComponent<TextMesh>().color = Color.green;
        }
	}
}
