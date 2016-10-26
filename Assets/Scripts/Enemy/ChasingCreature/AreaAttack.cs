using UnityEngine;
using System.Collections;

public class AreaAttack : MonoBehaviour {

	// Use this for initialization
	public GameObject monsterBullet;
	private Gun _gun;
	private bool _enableAttacking;
	public void Attack()
	{
		if (Character.current != null)
		{
			AudioManager.instance.Play ("evilLaugh");
			Instantiate (monsterBullet, transform.position, transform.rotation);
			Character.current.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
			_gun.DisableInput ();
			Camera.main.GetComponent<CameraStartBloom> ().StartBloomEffect ();

			Invoke ("EnableInput", 1.0f);
		}
	}

	void EnableInput()
	{
		_gun.EnableInput ();
	}


	void Start()
	{
		_gun = Character.current.GetComponentInChildren<Gun> ();
	}
		


}
