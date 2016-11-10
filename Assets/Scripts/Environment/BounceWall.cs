using UnityEngine;
using System.Collections;

public class BounceWall : MonoBehaviour {
    public float bounceBoost;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.rigidbody!= null)
        {
            print(col.relativeVelocity);
            float angle = transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
            Vector3 dir = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
            Vector3 velocity = col.relativeVelocity;
            velocity = 2.0f * (Vector3.Dot(dir ,velocity)) * dir - velocity;
            col.rigidbody.velocity = -velocity*bounceBoost;
			AudioManager.instance.Play ("wallBounce", gameObject);
			//col.rigidbody.AddForce(dir * bounceForce, ForceMode.Impulse);
        }
    }
}
