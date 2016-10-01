using UnityEngine;
using System.Collections;
using System;

public class PlasmaFire : FireBehavior
{    
    protected override void ExecuteFire()
    {
        Character.current.fuelChange += 1;
        var projectile = Instantiate(projectilePrefab);
        projectile.transform.position = _spawnTransform.position;
        projectile.GetComponent<CharacterBulletCollision>().SetDamage(damage);
        var bV = transform.TransformDirection(0.0f, 0.0f, speed) + _recoilTarget.velocity;
        bV.y = 0;
        projectile.GetComponent<Rigidbody>().velocity = bV;
        ApplyRecoilForce(bV, projectile.GetComponent<Rigidbody>().mass);
    }

    public Vector3 ApplyRecoilForce(Vector3 bulletVelocity, float bulletMass)
    {
        //var shipV = character.Velocity;
        Vector3 result = new Vector3();
        result.x = -bulletMass * bulletVelocity.x;//(shipV.x - bulletMass * bulletVelocity.x) / character.Mass;
        result.y = 0;//(shipV.y - bulletMass * bulletVelocity.y) / character.Mass;
        result.z = -bulletMass * bulletVelocity.z;//(shipV.z - bulletMass * bulletVelocity.z) / character.Mass;

        _recoilTarget.GetComponent<Rigidbody>().AddForce(result, ForceMode.Impulse);

        return result;
    }
}
