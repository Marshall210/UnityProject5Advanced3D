using System;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 speed; // Add speed each FixedUpdate
    public Vector3 addForce; // Add force
    public Vector3 addTorque; // Add force for rotation
    public Transform forcePosition; // Point for create force
    
    // Modes of forces
    public ForceMode forceMode;
    public ForceMode torqueMode;

    // Rigidbody component
    private Rigidbody rigidbody;
    
    
    private void Awake()
    {
        // Save rigidbody
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // Add force
        rigidbody.AddForce(addForce, forceMode);
        // Add force for rotation
        rigidbody.AddTorque(addTorque, torqueMode);
        
        // Add force from custom position
        
        if (forcePosition == null)
            return;
        
        rigidbody.AddForceAtPosition(addForce, forcePosition.position);
    }

    private void FixedUpdate()
    {
        // Add speed each FixedUpdate
        transform.position += speed;
    }
}
