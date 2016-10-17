using UnityEngine;
using System.Collections;

public class IncreaseDragOnCollision : MonoBehaviour {

	public float dragAmount;
    public float dragDuration;
	private VariableDrag _variableDrag;

    IEnumerator IncreasedDragWaitLoop(Collider other)
    {
        yield return new WaitForSeconds(5);
        other.GetComponent<Rigidbody>().drag -= dragAmount;
    }
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
            StartCoroutine(IncreasedDragWaitLoop(other));
            
        }
    }
}
