using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour {
    public Transform follow;
    public float speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (follow == null)
        {
            if(Character.current == null)
                return;
            follow = Character.current.transform;
        } 
        transform.position = Vector3.MoveTowards(transform.position, follow.position, speed*Time.deltaTime);
	}
}
