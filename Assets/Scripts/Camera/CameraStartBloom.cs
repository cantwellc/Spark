using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class CameraStartBloom : MonoBehaviour {
    public void StartBloomEffect()
    {
        StartCoroutine(bloomEffect());
    }

    IEnumerator bloomEffect()
    {
        Bloom bloom = this.GetComponent<Bloom>();
        bloom.enabled = true;
        float time = 0f, bloomTime = 2f;
        while (time <= bloomTime)
        {
            bloom.bloomIntensity += 0.4f;
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        time = 0;
        while (time <= bloomTime / 2f)
        {
            bloom.bloomIntensity -= 0.8f;
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        bloom.enabled = false;
        yield break;
    }
}
