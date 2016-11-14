using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class CameraStartBloom : MonoBehaviour {
    public void StartBloomEffect()
    {
        StartCoroutine(bloomEffect());
    }

	public void StopBloomEffect()
	{
		StartCoroutine (DimVFX ());
	}

    IEnumerator bloomEffect()
    {
        Bloom bloom = this.GetComponent<Bloom>();
        bloom.enabled = true;
        float time = 0f, bloomTime = 2f;
        bloom.bloomIntensity = 5.0f;
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

	IEnumerator DimVFX()
	{
		Debug.Log ("heeeeey!");
		Bloom bloom = this.GetComponent<Bloom>();
		bloom.enabled = true;
		float time = 0f, bloomTime = 2f;
		bloom.bloomIntensity = 15.0f;
		while (time <= bloomTime)
		{
			bloom.bloomIntensity -= 0.4f;
			time += Time.deltaTime*2;
			yield return new WaitForEndOfFrame();
		}
		time = 0;
		/*
		while (time <= bloomTime / 2f)
		{
			bloom.bloomIntensity += 0.8f;
			time += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}*/

		bloom.enabled = false;
		yield break;
	}
}
