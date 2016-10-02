using UnityEngine;
using System.Collections;

public class Boss1 : MonoBehaviour {

    public float timeBetweenActions;
    public float bulletFireCoolDown;

    public float bulletDamage;
    public float bulletSpeed;
    public float bulletExistTime;

    public float bhbSpeed;
    public GameObject blackHoleBomePrefab;
    public Transform blackholePos1;
    public Transform blackholePos2;
    public Transform bulletSpawnTransform, bulletSpawnTransform1, bulletSpawnTransform2, bulletSpawnTransform3;/////////
    public DroneHatch droneHatch1;

    float _timeRemainBetweenActions;
    float _bulletFireCoolDownRemain;
    Boss1Actions action;
    GameObject _bulletPrefab;
    bool _isActivated;

    enum Boss1Actions
    {
        ShootBlackHole = 0,
        ShootTrackingBullet = 1
    }
     
	void Start () {
        _isActivated = false;
        _timeRemainBetweenActions = 0;
        _bulletFireCoolDownRemain = 0;
        _bulletPrefab = (GameObject)Resources.Load("Prefabs/Enemy/EnemyBullet");
    }

    public void ActivateBoss()
    {
        _isActivated = true;
    }
	
	void Update () {
        if (!_isActivated) return;
        _timeRemainBetweenActions -= Time.deltaTime;
        if (_bulletFireCoolDownRemain >= 0) _bulletFireCoolDownRemain -= Time.deltaTime;
        if (_timeRemainBetweenActions > 0)
        {
            if(Boss1Actions.ShootBlackHole == action)
            {
                if(_bulletFireCoolDownRemain <= 0)
                {
                    _bulletFireCoolDownRemain = 100f;
                    Vector3 target;
                    float ran = Random.Range(0f, 1f);
                    if (ran >= 0.0f)
                        target = blackholePos1.position;
                    else
                        target = blackholePos2.position;
                    GameObject b = (GameObject) Instantiate(blackHoleBomePrefab);
                    b.transform.position = bulletSpawnTransform.position;
                    var targetVector = target - b.transform.position;
                    var flightTime = targetVector.magnitude / bhbSpeed;
                    var bhb = b.GetComponent<BlackHoleBomb>();
                    bhb.target = target;
                    bhb.flightTime = flightTime;
                    Destroy(b, timeBetweenActions-1f);
                    droneHatch1.Invoke("StartShooting", 2f);
                    droneHatch1.Invoke("StopShooting", timeBetweenActions);

                    b.GetComponent<Rigidbody>().velocity = targetVector.normalized * bhbSpeed;
                }
            }
            else if(Boss1Actions.ShootTrackingBullet == action)
            {
                if (_bulletFireCoolDownRemain <= 0)
                {
                    GameObject bulletInstance = Instantiate(_bulletPrefab, bulletSpawnTransform.position, transform.rotation) as GameObject;
                    bulletInstance.GetComponent<EnemyBulletCollision>().SetDamage(bulletDamage);
                    Rigidbody bulletRb = bulletInstance.GetComponent<Rigidbody>();
                    bulletRb.velocity = (Character.current.transform.position-bulletSpawnTransform.position).normalized * bulletSpeed;
                    Destroy(bulletInstance, bulletExistTime);
                    _bulletFireCoolDownRemain = bulletFireCoolDown;

                    /******************************************************************************************************************************/
                    GameObject bulletInstance1 = Instantiate(_bulletPrefab, bulletSpawnTransform2.position, transform.rotation) as GameObject;
                    bulletInstance1.GetComponent<EnemyBulletCollision>().SetDamage(bulletDamage);
                    Rigidbody bulletRb1 = bulletInstance1.GetComponent<Rigidbody>();
                    bulletRb1.velocity = (Character.current.transform.position - bulletSpawnTransform2.position).normalized * bulletSpeed;
                    Destroy(bulletInstance1, bulletExistTime);

                    GameObject bulletInstance2 = Instantiate(_bulletPrefab, bulletSpawnTransform1.position, transform.rotation) as GameObject;
                    bulletInstance2.GetComponent<EnemyBulletCollision>().SetDamage(bulletDamage);
                    Rigidbody bulletRb2 = bulletInstance2.GetComponent<Rigidbody>();
                    bulletRb1.velocity = (Character.current.transform.position - bulletSpawnTransform1.position).normalized * bulletSpeed;
                    Destroy(bulletInstance2, bulletExistTime);

                    GameObject bulletInstance3 = Instantiate(_bulletPrefab, bulletSpawnTransform3.position, transform.rotation) as GameObject;
                    bulletInstance3.GetComponent<EnemyBulletCollision>().SetDamage(bulletDamage);
                    Rigidbody bulletRb3 = bulletInstance3.GetComponent<Rigidbody>();
                    bulletRb3.velocity = (Character.current.transform.position - bulletSpawnTransform3.position).normalized * bulletSpeed;
                    Destroy(bulletInstance3, bulletExistTime);
                    /**********************************************************************************************************************************/
                }

            }
        }
        else
        {
            float ran = Random.Range(0f, 1f);
            if (ran >= 0.5f)
                action = Boss1Actions.ShootBlackHole;
            else
                action = Boss1Actions.ShootTrackingBullet; 
            _bulletFireCoolDownRemain = 0;
            _timeRemainBetweenActions = timeBetweenActions;
        }

    }
}
