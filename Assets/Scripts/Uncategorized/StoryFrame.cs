using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class StoryFrame : MonoBehaviour {
    public Transform cameraTargetTransform;
    public StoryFrame nextFrame;
    public float moveSpeed;

    bool _active;

    public void StartFrame()
    {
        _active = true;
    }

    void Update()
    {
        if (!_active) return;
        if (Camera.main.transform.position == cameraTargetTransform.position) EndFrame();
        else
        {
            float step = moveSpeed * Time.deltaTime;
            Vector3 pos = Camera.main.transform.position;
            pos = Vector3.MoveTowards(pos, cameraTargetTransform.position, step);
            Camera.main.transform.position = pos;
        }
    }

    public void EndFrame()
    {
        _active = false;
        NextFrame();
    }

    public void NextFrame()
    {
        if (nextFrame == null) return;
        nextFrame.StartFrame();
    }
}
