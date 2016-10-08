using UnityEngine;
using System.Collections;

public class CreateStunParticles : MonoBehaviour {

	public GameObject stunParticles;

	public void GenerateStunParticles()
	{
		Instantiate (stunParticles, Character.current.transform.position,Character.current.transform.rotation);
	}
}
