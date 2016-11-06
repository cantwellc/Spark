using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class StoryFrame : MonoBehaviour {
    public UnityEvent OnFrameStart;
    public UnityEvent OnFrameEnd;

    public Transform cameraTargetTransform;
    public StoryFrame nextFrame;
    public float timeToNextFrame;
    public float cameraSpeed;

    private bool _active;
    private bool _transition;

    public void StartFrame()
    {
        _active = true;
        OnFrameStart.Invoke();
        StartCoroutine(TransitionTimer());
    }

    private IEnumerator TransitionTimer()
    {
        yield return new WaitForSeconds(timeToNextFrame);
        _transition = true;
        yield break;
    }

    void Update()
    {
        if (!_active) return;
        //if (Camera.main.transform.position == cameraTargetTransform.position) EndFrame();
        if (_transition) EndFrame();
        else
        {
            float step = cameraSpeed * Time.deltaTime;
            Vector3 pos = Camera.main.transform.position;
            pos = Vector3.MoveTowards(pos, cameraTargetTransform.position, step);
            Camera.main.transform.position = pos;
        }
    }

    public void EndFrame()
    {
        _active = false;
        OnFrameEnd.Invoke();
        NextFrame();
    }

    public void NextFrame()
    {
		if (nextFrame == null)
		{
            EventManager.TriggerEvent(EventManager.Events.LOAD_NEXT_SCENE);
//			SceneManager.LoadScene ("TutorialLevel");
			return;
		}
        nextFrame.StartFrame();
    }
}
