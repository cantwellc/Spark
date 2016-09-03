using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public Gun Gun;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Gun.Shoot();
    }

}
