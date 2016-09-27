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
    public Transform bulletSpawnTransform;

    float _timeRemainBetweenActions;
    float _bulletFireCoolDownRemain;
    Boss1Actions action;
    GameObject _bulletPrefab;

    enum Boss1Actions
    {
        ShootBlackHole = 0,
        ShootTrackingBullet = 1
    }
     
	void Start () {
        _timeRemainBetweenActions = 0;
        _bulletFireCoolDownRemain = 0;
        _bulletPrefab = (GameObject)Resources.Load("Prefabs/Enemy/EnemyBullet");
    }
	
	void Update () {
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
                    if (ran >= 0.5f)
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
