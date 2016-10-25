using UnityEngine;
using System.Collections;
using System;

public class TraceFillEffect : MonoBehaviour {
    public UIImageFill imageFill1;
    public UIImageFill imageFill2;
    public float totalFillTime;
    public float fillDelay;

	public void StartEffect()
    {
        StartCoroutine(CoStartEffect());
    }

    private IEnumerator CoStartEffect()
    {
        imageFill1.StartFill(totalFillTime);
        yield return new WaitForSeconds(fillDelay);
        imageFill2.StartFill(totalFillTime);
    }
}
