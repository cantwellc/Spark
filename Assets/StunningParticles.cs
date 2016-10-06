using UnityEngine;
using System.Collections;

public class StunningParticles : MonoBehaviour {

	private Vector3 _speedOfCharacterBefore;
	private bool _stunCharacter = false;
	public float stunForSeconds ;
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Character")
		{
			_speedOfCharacterBefore = other.gameObject.GetComponent<Rigidbody> ().velocity;
			other.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
		}
	}

	void Start()
	{
		Destroy (gameObject, stunForSeconds);
	}

	void Update()
	{
		Character.current.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
	}
}
