using UnityEngine;
using System.Collections;

public class Flash : MonoBehaviour {

    private bool active = true;
    public float flashTime = 1.0f;
    Renderer rend;
    float t = 0;
    // Update is called once per frame

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update () {
        t += Time.deltaTime;
        if(t>=flashTime)
        {
            t = 0;
            active = !active;
        }

        rend.enabled = active;

	}
}
