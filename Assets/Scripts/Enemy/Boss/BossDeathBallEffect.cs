using UnityEngine;
using System.Collections;

public class BossDeathBallEffect : MonoBehaviour {

    public float expandSpeed;
    public float expandTime;

    public void StartDeathEffect()
    {
        transform.parent = null;
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Animator>().SetTrigger("Dead");
        Destroy(this.gameObject, expandTime);
    }

    IEnumerator bloomEffect()
    {
        GetComponent<MeshRenderer>().enabled = true;
        yield break;
    }
}
