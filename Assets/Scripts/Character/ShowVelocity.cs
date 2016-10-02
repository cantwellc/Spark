using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowVelocity : MonoBehaviour {
    public Text velocityText;
    public Rigidbody rigidBody;

    void Update()
    {
        velocityText.text = rigidBody.velocity.magnitude.ToString();
    }	
}
