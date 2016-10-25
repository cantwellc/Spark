using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System;

public class FlashImage : MonoBehaviour {
    public UnityEvent imageFlashOn;
    public UnityEvent imageFlashOff;

    public Image image;
    public float onTime;
    public float offTime;

    bool flashing;

    void Start()
    {
        StartFlashing();
    }

    public void StartFlashing()
    {
        flashing = true;
        StartCoroutine(Flash());
    }

    public void StopFlashing()
    {
        flashing = false;
        if(image != null) image.gameObject.SetActive(false);
    }

    public IEnumerator Flash()
    {
        if (image == null) yield break;
        while (flashing)
        {
            if (!image.gameObject.activeInHierarchy)
            {                
                yield return StartCoroutine(ActivateImageAfterWait());
            }
            else
            {                
                yield return StartCoroutine(DeactivateImageAfterWait());
            }
        }
    }

    private IEnumerator ActivateImageAfterWait()
    {
        yield return new WaitForSeconds(offTime);
        imageFlashOn.Invoke();
        image.gameObject.SetActive(true);
    }

    private IEnumerator DeactivateImageAfterWait()
    {
        yield return new WaitForSeconds(onTime);
        imageFlashOff.Invoke();
        image.gameObject.SetActive(false);
    }

    private IEnumerator NotifyOff()
    {
        imageFlashOff.Invoke();
        yield break;
    }
}
