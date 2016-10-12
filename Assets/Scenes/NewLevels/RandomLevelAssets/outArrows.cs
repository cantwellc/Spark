using UnityEngine;
using System.Collections;

public class outArrows : MonoBehaviour {

    public GameObject arrows;
	private bool _triggered = true;
   	

	void Start()
	{
        if (arrows != null)
        {
            arrows.SetActive(false);
        }
	}

	void Flash()
    {
        if (arrows.activeSelf)
            arrows.SetActive(false);
        else
            arrows.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        
		if (_triggered)
		{
			arrows.SetActive (true);
			InvokeRepeating ("Flash", 1.2f, 0.5f);
			_triggered = false;
		}

    }
}
