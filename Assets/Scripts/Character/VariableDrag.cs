using UnityEngine;
using System.Collections;

/// <summary>
/// Simple component that allows a RigidBody drag to
/// vary with velocity.  
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class VariableDrag : MonoBehaviour {
    //public float minVelocityThreshold;
    //public float minDrag; // Anything below the minVelocityThreshold will have minDrag
    //public float maxVelocityThreshold;
    //public float maxDrag; // Anything above the maxVelocityThreshold will have maxDrag
    public AnimationCurve dragByVelocityCurve;
	public float constantDrag = 0.0f;

    private Rigidbody _rigidBody;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

	void FixedUpdate()
    {
        var v = _rigidBody.velocity.magnitude;
        float drag = dragByVelocityCurve.Evaluate(v);
        //if (v < minVelocityThreshold) drag = minDrag;
        //else if (v > maxVelocityThreshold) drag = maxDrag;
        //else
        //{
        //    float ratio = (v - minVelocityThreshold) / (maxVelocityThreshold - minVelocityThreshold);
        //    Debug.Log("Ratio: " + dragScalingCurve.Evaluate(ratio).ToString()); 
        //    drag = dragScalingCurve.Evaluate(ratio) * (maxDrag - minDrag) + minDrag;
        //}

		_rigidBody.drag = drag+ constantDrag;
    }
}
