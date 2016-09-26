using UnityEngine;
using System.Collections;
using System;

public class PlasmaBurst : FireBehavior
{
    public Character character;

    protected override void ExecuteFire()
    {
        Ramming();
    }

    void Ramming()
    {
        character.maxVelocity = 50;
        character.Velocity *= 2;

        character.ramEffect.Play();
        //Has a high value because we dont want to take currentVelocity Account too much
		character.Velocity += transform.forward * ChargeRatio * -100;

        // Make this a percentage based thing so we aren't stuck with scale=0.6
        // Changing models will need different scales.
//        character.transform.localScale = new Vector3(0.57f, 0.6f, 0.6f);

        Invoke("StopRamming", 0.3f);
        Invoke("StopParticles", 0.5f);
    }
    void StopRamming()
    {
        character.maxVelocity = 10;
//        character.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

        character.Velocity = transform.forward * -2;
    }
    void StopParticles()
    {
        character.ramEffect.Stop();
    }
}
