using UnityEngine;
using System.Collections;

public class PlasmaBurstVisualEffect : MonoBehaviour {

    public ParticleSystem RamEffect;

    public void PlayVisualEffect()
    {
        RamEffect.Play();
    }
}
