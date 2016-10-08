using UnityEngine;
using System.Collections;

public class AreaAttack : MonoBehaviour {

	// Use this for initialization
	public GameObject monsterBullet;
	private Gun _gun;
	private bool _enableAttacking;
	public void Attack()
	{
		Instantiate (monsterBullet, transform.position, transform.rotation);

	}
	void Start()
	{
		_gun = Character.current.GetComponentInChildren<Gun> ();
	}
		


}
