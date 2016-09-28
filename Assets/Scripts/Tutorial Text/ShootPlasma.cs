using UnityEngine;
using System.Collections;

public class ShootPlasma : MonoBehaviour {

    public GameObject enemy1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!enemy1)
        {
            GetComponent<TextMesh>().color = Color.green;
            GetComponent<TextMesh>().text = "GOOD JOB!";
        }
	}
}
