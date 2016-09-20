using UnityEngine;
using System.Collections;

public class ParticleFollow : MonoBehaviour 
{
	private Transform _characterBulletSpawnTransform;


	void Start()
	{
		_characterBulletSpawnTransform = GameObject.Find ("CharacterBulletSpawnPoint").transform;
	}


	void Update()
	{
        if(_characterBulletSpawnTransform)
		    transform.position = _characterBulletSpawnTransform.position;
	}


}
