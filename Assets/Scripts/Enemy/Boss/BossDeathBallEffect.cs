using UnityEngine;
using System.Collections;

public class BossDeathBallEffect : MonoBehaviour {

    public float expandSpeed;
    public float expandTime;

    public void StartDeathEffect()
    {
        transform.parent = null;
        StartCoroutine(bloomEffect());
    }

    IEnumerator bloomEffect()
    {
        GetComponent<MeshRenderer>().enabled = true;
        float time = 0f;
        while (time <= expandTime)
        {
            Vector3 scale = transform.localScale;
            scale.x += expandSpeed;
            scale.y += expandSpeed;
            scale.z += expandSpeed;
            transform.localScale = scale;

            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        time = 0;
        while (time <= expandTime / 2f)
        {
            Vector3 scale = transform.localScale;
            scale.x -= expandSpeed;
            scale.y -= expandSpeed;
            scale.z -= expandSpeed;
            transform.localScale = scale;
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        GetComponent<MeshRenderer>().enabled = false;
        yield break;
    }
}
