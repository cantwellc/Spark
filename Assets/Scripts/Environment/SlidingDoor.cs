using UnityEngine;
using System.Collections;

public class SlidingDoor : MonoBehaviour {
    public bool opened;
	public bool canSlam;

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
				if (canSlam == true)
				{
					AudioManager.instance.Play ("doorSlam", gameObject);
					canSlam = false;
				}
				               
				moving = false;
            }
        }
	}

    public void OpenDoor()
    {
		if (!opened)
		{
			AudioManager.instance.Play ("openDoor", gameObject);
			canSlam = true;
		}

		moving = true;
        opened = true;
    }

    public void CloseDoor()
    {
		if (opened == true)
		{
			AudioManager.instance.Play ("closeDoor", gameObject);
			canSlam = true;
		}
		
		moving = true;
        opened = false;
    }
}
