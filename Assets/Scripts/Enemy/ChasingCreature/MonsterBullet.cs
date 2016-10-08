using UnityEngine;
using System.Collections;

public class MonsterBullet : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Character")
		{
			Character.current.GetComponent<CharacterHealth> ().TakeDamage (950);

		}
	}
}
