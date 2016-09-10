using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{

	public float projectileSpeed;
	public Transform bulletSpawnPoint;
	public GameObject enemyProjectilePrefab;
	public float fireIntervalInSeconds = 1;
	public float senseRadius ;
	public float damage;
	public LayerMask layerMask;


	private Rigidbody _rb;

	void Start () 
	{
		//Enemy will attack after 1 seconds and then repeatedly in every fireIntervalInSeconds
		InvokeRepeating ("Attack", 1, fireIntervalInSeconds);
	}

	void Attack()
	{
		/*If we are close to the player , We Basically construct an imaginary sphere on the position of the Enemy with
		senseRadius as its radius and check whether that sphere intersects with player (we only check players with setting layerMask to player */
		//TODO: We invoke CheckSphere throughout the game, should be a better way than this

		if (Physics.CheckSphere (transform.position, senseRadius,layerMask))
		{
			//Fire the bullet;
			GameObject bulletInstance = Instantiate (enemyProjectilePrefab, bulletSpawnPoint.position, transform.rotation) as GameObject;
			bulletInstance.GetComponent<EnemyBulletCollision> ().SetDamage (damage);
			Rigidbody bulletRb = bulletInstance.GetComponent<Rigidbody> ();
			bulletRb.velocity = bulletRb.transform.forward * projectileSpeed;
			//We dont want it hang around too much.
			Destroy (bulletInstance, 5.0f);
		}
	}
}
