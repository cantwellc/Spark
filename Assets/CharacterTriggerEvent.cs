using UnityEngine;
using UnityEngine.Events;

public class CharacterTriggerEvent : MonoBehaviour {
    public UnityEvent OnCharacterTrigger;
	
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Character") OnCharacterTrigger.Invoke();
    }
}
