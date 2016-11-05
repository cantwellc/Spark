using UnityEngine;
using System.Collections;

public class SlidingDoor : MonoBehaviour {
    public bool opened;

    public float openSpeed;
    public float closeSpeed;

    public GameObject door;
    // Use this for initialization
    bool moving;
	void Start () {
	    if(opened)
        {
            door.transform.localPosition = new Vector3(10, 0, 0);
        }
        moving = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(moving)
        {
            Vector3 target = new Vector3(10, 0, 0);
            if (opened)
            {
                target = new Vector3(10, 0, 0);
            }
            else
            {
                target = Vector3.zero;
            }
            float speed = opened ? openSpeed : closeSpeed;
            door.transform.localPosition = Vector3.MoveTowards(door.transform.localPosition, target, speed);
            if (door.transform.localPosition == target)
            {
                moving = false;
            }
        }
	}

    public void OpenDoor()
    {
        moving = true;
        opened = true;
    }

    public void CloseDoor()
    {
        moving = true;
        opened = false;
    }
}
