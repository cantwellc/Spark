using UnityEngine;
using System.Collections;

public class DeactivateOnRightClick : MonoBehaviour {

	void OnMouseDown()
    {
        if (!Input.GetMouseButton(1)) return;
        gameObject.SetActive(false);
    }
}
