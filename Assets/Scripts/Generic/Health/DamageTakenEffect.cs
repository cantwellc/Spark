using UnityEngine;
using System.Collections;

public class DamageTakenEffect : MonoBehaviour {

	void TakeDamageEffect()
    {
        Debug.Log(gameObject.name + " has taken damage.  Showing Visual Effect.");
    }
}
