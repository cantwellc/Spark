using UnityEngine;
using System.Collections;

public class IncreaseDragOnCollision : MonoBehaviour {

	public float dragAmount;
    public float dragDuration;
	private VariableDrag _variableDrag;

    IEnumerator IncreasedDragWaitLoop(Collider other)
    {
        yield return new WaitForSeconds(dragDuration);
        other.GetComponent<VariableDrag>().constantDrag -= dragAmount;
    }
    // Use this for initialization
    void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
			other.GetComponent<VariableDrag>().constantDrag += dragAmount;
            StartCoroutine(IncreasedDragWaitLoop(other));
            
        }
    }
}
