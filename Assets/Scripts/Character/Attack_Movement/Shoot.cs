using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour 
{

    public Gun gun;

    void Update()
    {
		if (Input.GetKeyDown (KeyCode.Space))
		{
			gun.PrimaryFire ();
		}
    }

}
