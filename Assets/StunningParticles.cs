using UnityEngine;
using System.Collections;

public class StunningParticles : MonoBehaviour {

	private Gun _gun;
	public float stunForSeconds ;
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Character")
		{
			other.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
		}
	}

	void Start()
	{
		Destroy (gameObject, stunForSeconds);
		_gun = Character.current.GetComponentInChildren<Gun> ();

	}

	void Update()
	{
		Character.current.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
		Camera.main.GetComponent<CameraShake> ().Shake ();
		_gun.DisableInput ();
	}

	void OnDestroy()
	{
		_gun.EnableInput ();
	}
}
