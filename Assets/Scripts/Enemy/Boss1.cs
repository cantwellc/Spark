using UnityEngine;
using System.Collections.Generic;

public class Boss1 : MonoBehaviour {

//    public float timeBetweenActions;
    public float shootPhaseTime;
    public float dronePhaseTime;
    public float bulletFireCoolDown;

    public float bulletDamage;
    public float bulletSpeed;
    public float bulletExistTime;

    //public float bhbSpeed;
    //public GameObject blackHoleBomePrefab;
    //public Transform blackholePos1;
    //public Transform blackholePos2;
    //public Transform bulletSpawnTransform, bulletSpawnTransform1, bulletSpawnTransform2, 
    //    bulletSpawnTransform3, bulletSpawnTransform4, 
    //    bulletSpawnTransform5;/////////
    public List<Transform> bulletSpawnTransforms;
    public DroneHatch droneHatch1;
    public DroneHatch droneHatch2;
    public GameObject droneZone1;
    public GameObject droneZone2;

    float _timeRemainBetweenActions;
    float _bulletFireCoolDownRemain;
    Boss1Actions action;
    GameObject _bulletPrefab;
    bool _isActivated;
    bool _bhbPos1;
    bool _bhbPos2;
    float _changeActionProbability = 0.5f;
    bool _shootPhase;


    enum Boss1Actions
    {
        ShootBlackHole = 0,
        ShootTrackingBullet = 1
    }
     
	void Start () {
        _isActivated = false;
        _bhbPos1 = true;
        _bhbPos2 = false;
        _timeRemainBetweenActions = 0;
        _bulletFireCoolDownRemain = 0;
        _bulletPrefab = (GameObject)Resources.Load("Prefabs/Enemy/EnemyBullet");
    }

    public void ActivateBoss()
    {
        _isActivated = true;
    }


    public void addSelfToCameraTargetLocation()
    {
        CameraFollow.mainCamera.targetLocation2 = transform;
    }

    void Update () {
        if (!_isActivated || Character.current == null) return;
        _timeRemainBetweenActions -= Time.deltaTime;
        if (_bulletFireCoolDownRemain >= 0) _bulletFireCoolDownRemain -= Time.deltaTime;
        if (_timeRemainBetweenActions > 0)
        {
            if(Boss1Actions.ShootBlackHole == action)
            {
                if(_bulletFireCoolDownRemain <= 0)
                {
                    _bulletFireCoolDownRemain = 100f;
                    if(_bhbPos1)
                    {
                        droneZone1.transform.position = this.transform.position;
                        droneZone1.SetActive(true);
                        droneZone1.GetComponent<TimedEvent>().StartTimer();
                        _bhbPos1 = false;
                    } else
                    {
                        droneZone2.transform.position = this.transform.position;
                        droneZone2.SetActive(true);
                        droneZone2.GetComponent<TimedEvent>().StartTimer();
                        _bhbPos1 = true;
                    }
                    /*_bulletFireCoolDownRemain = 100f;
                    Vector3 target;
                    float ran = Random.Range(0f, 1f);
                    //assigned a value to avoid error !
                    target = blackholePos1.position;
                    if (_bhbPos1)
                    {
                        target = blackholePos1.position;
                        _bhbPos1 = false;
                        _bhbPos2 = true;
                    }
                    else if(_bhbPos2)
                    {
                        target = blackholePos2.position;
                        _bhbPos1 = true;
                        _bhbPos2 = false;
                    }
                    GameObject b = (GameObject) Instantiate(blackHoleBomePrefab);
                    b.transform.position = bulletSpawnTransform.position;
                    var targetVector = target - b.transform.position;
                    var flightTime = targetVector.magnitude / bhbSpeed;
                    var bhb = b.GetComponent<BlackHoleBomb>();
                    bhb.target = target;
                    bhb.flightTime = flightTime;
                    Destroy(b, timeBetweenActions-1f);
                    if(_bhbPos1)
                    {
                        droneHatch2.Invoke("StartShooting", 2f);
                        droneHatch2.Invoke("StopShooting", timeBetweenActions);
                    }
                    else
                    {
                        droneHatch1.Invoke("StartShooting", 2f);
                        droneHatch1.Invoke("StopShooting", timeBetweenActions);
                    }

                    b.GetComponent<Rigidbody>().velocity = targetVector.normalized * bhbSpeed;*/
                }
            }
            else if(Boss1Actions.ShootTrackingBullet == action)
            {
                
                droneZone1.SetActive(false);
                droneZone2.SetActive(false);
                if (_bulletFireCoolDownRemain <= 0)
                {
                    foreach(var trans in bulletSpawnTransforms)
                    {
                        GameObject bulletInstance = Instantiate(_bulletPrefab, trans.position, transform.rotation) as GameObject;
                        bulletInstance.GetComponent<EnemyBulletCollision>().SetDamage(bulletDamage);
                        Rigidbody bulletRb = bulletInstance.GetComponent<Rigidbody>();
                        bulletRb.velocity = trans.forward.normalized * bulletSpeed;
                        Destroy(bulletInstance, bulletExistTime);
                        Physics.IgnoreCollision(bulletInstance.GetComponent<Collider>(), GetComponent<Collider>());
                    }
                    _bulletFireCoolDownRemain = bulletFireCoolDown;
                    //GameObject bulletInstance = Instantiate(_bulletPrefab, bulletSpawnTransform.position, transform.rotation) as GameObject;
                    //bulletInstance.GetComponent<EnemyBulletCollision>().SetDamage(bulletDamage);
                    //Rigidbody bulletRb = bulletInstance.GetComponent<Rigidbody>();
                    //bulletRb.velocity = (Character.current.transform.position-bulletSpawnTransform.position).normalized * bulletSpeed;
                    //Destroy(bulletInstance, bulletExistTime);
                    //_bulletFireCoolDownRemain = bulletFireCoolDown;

                    ///******************************************************************************************************************************/
                    //GameObject bulletInstance1 = Instantiate(_bulletPrefab, bulletSpawnTransform2.position, transform.rotation) as GameObject;
                    //bulletInstance1.GetComponent<EnemyBulletCollision>().SetDamage(bulletDamage);
                    //Rigidbody bulletRb1 = bulletInstance1.GetComponent<Rigidbody>();
                    //bulletRb1.velocity = (Character.current.transform.position - bulletSpawnTransform2.position).normalized * bulletSpeed;
                    //Destroy(bulletInstance1, bulletExistTime);

                    //GameObject bulletInstance2 = Instantiate(_bulletPrefab, bulletSpawnTransform1.position, transform.rotation) as GameObject;
                    //bulletInstance2.GetComponent<EnemyBulletCollision>().SetDamage(bulletDamage);
                    //Rigidbody bulletRb2 = bulletInstance2.GetComponent<Rigidbody>();
                    //bulletRb1.velocity = (Character.current.transform.position - bulletSpawnTransform1.position).normalized * bulletSpeed;
                    //Destroy(bulletInstance2, bulletExistTime);

                    //GameObject bulletInstance3 = Instantiate(_bulletPrefab, bulletSpawnTransform3.position, transform.rotation) as GameObject;
                    //bulletInstance3.GetComponent<EnemyBulletCollision>().SetDamage(bulletDamage);
                    //Rigidbody bulletRb3 = bulletInstance3.GetComponent<Rigidbody>();
                    //bulletRb3.velocity = (Character.current.transform.position - bulletSpawnTransform3.position).normalized * bulletSpeed;
                    //Destroy(bulletInstance3, bulletExistTime);


                    //GameObject bulletInstance4 = Instantiate(_bulletPrefab, bulletSpawnTransform4.position, transform.rotation) as GameObject;
                    //bulletInstance4.GetComponent<EnemyBulletCollision>().SetDamage(bulletDamage);
                    //Rigidbody bulletRb4 = bulletInstance4.GetComponent<Rigidbody>();
                    //bulletRb4.velocity = (Character.current.transform.position - bulletSpawnTransform4.position).normalized * bulletSpeed;
                    //Destroy(bulletInstance4, bulletExistTime);


                    //GameObject bulletInstance5 = Instantiate(_bulletPrefab, bulletSpawnTransform5.position, transform.rotation) as GameObject;
                    //bulletInstance5.GetComponent<EnemyBulletCollision>().SetDamage(bulletDamage);
                    //Rigidbody bulletRb5 = bulletInstance5.GetComponent<Rigidbody>();
                    //bulletRb5.velocity = (Character.current.transform.position - bulletSpawnTransform5.position).normalized * bulletSpeed;
                    //Destroy(bulletInstance5, bulletExistTime);

                    /**********************************************************************************************************************************/
                }

            }
        }
        else
        {
            float ran = Random.Range(0f, 1f);
            if(ran <= _changeActionProbability)
            {
                _changeActionProbability = 0.5f;
                if (_shootPhase)
                {
                    action = Boss1Actions.ShootBlackHole;
                    _timeRemainBetweenActions = dronePhaseTime;
                    _shootPhase = false;
                }
                else
                {
                    action = Boss1Actions.ShootTrackingBullet;
                    _timeRemainBetweenActions = shootPhaseTime;
                    _shootPhase = true;
                }
            }
            else
            {
                _changeActionProbability += 0.1f;
            }
            //if (ran >= 0.5f)
            //    action = Boss1Actions.ShootBlackHole;
            //else
            //    action = Boss1Actions.ShootTrackingBullet; 
            _bulletFireCoolDownRemain = 0;
//            _timeRemainBetweenActions = timeBetweenActions;
        }

    }
}
