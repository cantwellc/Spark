using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class FlashImage : MonoBehaviour {

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
                image.gameObject.SetActive(true);
                yield return new WaitForSeconds(offTime);
            }
            else
            {
                image.gameObject.SetActive(false);
                yield return new WaitForSeconds(offTime);
            }
        }
    }
}
