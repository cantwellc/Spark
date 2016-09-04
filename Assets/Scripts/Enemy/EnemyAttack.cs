using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float Speed;
	public Transform BulletSpawnPoint;
	public GameObject EnemyProjectilePrefab;
	public float FireIntervalInSeconds = 1;
	public float SenseRadius ;
	public float Damage;
	public LayerMask LayerMask;


	private Rigidbody rb;

	void Start () 
	{
		//Enemy will attack after 1 seconds and then repeatedly in every fireIntervalInSeconds
		InvokeRepeating ("Attack", 1, FireIntervalInSeconds);
	}

	void Attack()
	{
		/*If we are close to the player , We Basically construct an imaginary sphere on the position of the Enemy with
		senseRadius as its radius and check whether that sphere intersects with player (we only check players with setting layerMask to player */
		//TODO: We invoke CheckSphere throughout the game, should be a better way than this

		if (Physics.CheckSphere (transform.position, SenseRadius,LayerMask))
		{
			//Fire the bullet;
			GameObject bulletInstance = Instantiate (EnemyProjectilePrefab, BulletSpawnPoint.position, transform.rotation) as GameObject;
			bulletInstance.GetComponent<EnemyBulletCollision> ().SetDamage (Damage);
			Rigidbody bulletRb = bulletInstance.GetComponent<Rigidbody> ();
			bulletRb.velocity = bulletRb.transform.forward * Speed;
			//We dont want it hang around too much.
			Destroy (bulletInstance, 5.0f);
		}
	}
}
