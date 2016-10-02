using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
    public enum BulletType
    {
        Plasma,
        SprayPlasma,
        Flame,
        SprayFlame,
        Bolt,
        Laser
    }

    public enum FiringType
    {
        Tracking,
        Spiral,
        AlternatingFire
    }


    public BulletType bulletType;
    public float bulletDamage;
    public float bulletSpeed;
	public float bulletScale;
    public float bulletExistTime;
    public float fireIntervalInSeconds;
    public float turnSpeed;
    public FiringType firingType;
    public Transform bulletSpawnPoint;
    public float alternateShootingDirInDegree1;
    public float alternateShootingDirInDegree2;
    public float alternateShootingTime;   //Time to shoot in each direction

    public bool _startShooting = false;
    string _bulletPrefabName;
    float _fireCooldown = 0f;
    GameObject _bulletPrefab;
    Transform _targetTransform;
    int _alternateShootingDir = 0;
    float _alternateShootingTimeRemain = 0;

	// Use this for initialization
	void Start () {
	    switch(bulletType)
        {
            case BulletType.Plasma:
                _bulletPrefabName = "Prefabs/Enemy/EnemyBullet";
                _bulletPrefab = (GameObject)Resources.Load("Prefabs/Enemy/EnemyBullet");
                break;
            default:
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if(_startShooting)
        {
            if(Character.current == null)
            {
                return;
            }
            if(_fireCooldown > 0)
                _fireCooldown -= Time.deltaTime;
            _targetTransform = Character.current.transform;
            if (FiringType.Tracking == firingType)
            {
                //Recommended turn speed: 60
                Vector3 dir = _targetTransform.position - transform.position;
                Quaternion dest = Quaternion.LookRotation(dir.normalized);
                transform.rotation = Quaternion.Slerp(transform.rotation, dest, Time.deltaTime * turnSpeed / Quaternion.Angle(transform.rotation, dest));

                if (_fireCooldown <= 0)
                {
                    if (bulletType == BulletType.SprayPlasma)
                        SprayShootForward();
                    else
                        ShootForward();
                }
            }
            else if (FiringType.Spiral == firingType)
            {
                //Recommended turn speed: 1
                transform.Rotate(0, turnSpeed, 0);
                if (_fireCooldown <= 0)
                {
                    if (bulletType == BulletType.SprayPlasma)
                        SprayShootForward();
                    else
                        ShootForward();
                }
            }
            else if(FiringType.AlternatingFire == firingType)
            {
                if(_alternateShootingTimeRemain > 0)
                {
                    _alternateShootingTimeRemain -= Time.deltaTime;
                    if (_fireCooldown <= 0)
                    {
                        if (bulletType == BulletType.SprayPlasma)
                            SprayShootForward();
                        else
                            ShootForward();
                    }
                }
                else
                {
                    alternateTurn();
                }
            }
        }
	}

    void alternateTurn()
    {
        if (_alternateShootingDir == 0)
        {
            Quaternion dest = Quaternion.Euler(0, alternateShootingDirInDegree2, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, dest, Time.deltaTime * turnSpeed / Quaternion.Angle(transform.rotation, dest));
            if (Quaternion.Angle(transform.rotation, dest) <= 1)
            {
                _alternateShootingDir = 1;
                _alternateShootingTimeRemain = alternateShootingTime;
            }
        }
        else
        {
            Quaternion dest = Quaternion.Euler(0, alternateShootingDirInDegree1, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, dest, Time.deltaTime * turnSpeed / Quaternion.Angle(transform.rotation, dest));
            if (Quaternion.Angle(transform.rotation, dest) <= 1)
            {
                _alternateShootingDir = 0;
                _alternateShootingTimeRemain = alternateShootingTime;
            }
        }

    }

    public void DestroyedByBlackHole()
    {
        if(GetComponent<Armor>() == null || GetComponent<Armor>().armorType != Armor.ArmorType.ImmuneToBlackHole)
            Destroy(this.gameObject);
    }

    void AbsorbPlasma()
    {

    }

    void ShootForward()
    {
        GameObject bulletInstance = Instantiate(_bulletPrefab, bulletSpawnPoint.position, transform.rotation) as GameObject;
        bulletInstance.GetComponent<EnemyBulletCollision>().SetDamage(bulletDamage);
        Rigidbody bulletRb = bulletInstance.GetComponent<Rigidbody>();
        bulletRb.velocity = bulletRb.transform.forward * bulletSpeed;
		bulletInstance.transform.localScale = new Vector3 (bulletScale, bulletScale,bulletScale);
        Destroy(bulletInstance, bulletExistTime);
        _fireCooldown = fireIntervalInSeconds;
    }

    void SprayShootForward()
    {
        for(int a=0;a!=3;++a)
        {
            
            GameObject bulletInstance = Instantiate(_bulletPrefab, bulletSpawnPoint.position, transform.rotation) as GameObject;
            bulletInstance.GetComponent<EnemyBulletCollision>().SetDamage(bulletDamage);
            Rigidbody bulletRb = bulletInstance.GetComponent<Rigidbody>();
            bulletRb.transform.Rotate(0, -10f + 10f * a, 0);
            bulletRb.velocity = bulletRb.transform.forward * bulletSpeed;
            Destroy(bulletInstance, bulletExistTime);
        }
        _fireCooldown = fireIntervalInSeconds;

    }

    void StartShooting()
    {
        _startShooting = true;
    }

    void StopShooting()
    {
        _startShooting = false;
    }
}
