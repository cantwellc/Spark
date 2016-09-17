using UnityEngine;
using System.Collections;

/// <summary>
/// Simple script to attach to objects that should receive gravity.
/// A gravitational object must have a RigidBody component to ensure it has mass.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Gravitational : MonoBehaviour { }
