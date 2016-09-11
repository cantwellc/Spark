using UnityEngine;
using System.Collections;

public class ParticleFollow : MonoBehaviour 
{
	private Transform _characterBulletSpawnTransform;


	void Start()
	{
		_characterBulletSpawnTransform = GameObject.Find ("BulletSpawnPoint").transform;
	}


	void Update()
	{
		transform.position = _characterBulletSpawnTransform.position;
	}


}
