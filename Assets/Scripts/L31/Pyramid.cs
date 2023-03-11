using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour
{
    public float radius; // Radius for rotation
    public float forceReaction; // Force for collision reaction
    private void OnCollisionEnter(Collision other)
    {
        // Activate children
        foreach (Transform shard in transform)
            shard.gameObject.SetActive(true);

        // Find all collider components in zone
        var sphere = Physics.OverlapSphere(transform.position, 10);
        var elements = new List<Rigidbody> ();

        // Setup collider components to list
        foreach (var collider1 in sphere)
        {
            if (collider1.attachedRigidbody != null && !elements.Contains(collider1.attachedRigidbody))
                elements.Add(collider1.attachedRigidbody);
        }

        // Add rotation and force for each shard of pyramid
        foreach (var rb in elements) {
            var randomRot = new Vector3 (Random.Range (-1.1f, 1.1f), Random.Range (-1.1f, 1.1f), Random.Range (-1.1f, 1.1f));
            rb.AddTorque(randomRot * radius);
            rb.AddExplosionForce (forceReaction, other.GetContact(0).point,  1, 0, ForceMode.Impulse);
        }

        // Deactivate pyramid view
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
        
        // Remove force from object that collided with pyramid 
        other.collider.attachedRigidbody.velocity = Vector3.zero;
    }
}
