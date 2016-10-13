using UnityEngine;
using System.Collections;

public class IncreaseDragOnCollision : MonoBehaviour {

	public float dragAmount;
	private VariableDrag _variableDrag;

	// Use this for initialization
	void Start () 
	{
		_variableDrag = Character.current.GetComponent<VariableDrag> ();	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
			other.GetComponent<Rigidbody>().drag += dragAmount;
        }
    }
}
