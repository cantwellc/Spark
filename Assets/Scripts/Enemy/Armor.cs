using UnityEngine;
using System.Collections;

public class Armor : MonoBehaviour {

    public enum ArmorType
    {
        ImmuneToPlasma,
        Reflective,
        ImmuneToBlackHole,
        DamageReduction,
        AbsorbPlasma
    }

    public ArmorType armorType;
    public float damageReduction; //0-1

    // Use this for initialization
    void Start () {
	
	}
	
}
