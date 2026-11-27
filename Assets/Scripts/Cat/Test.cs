
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private HashSet<Collider> detectedColliders = new HashSet<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(
            "TRIGGER ENTER : " + other.name +
            " | Tag : " + other.tag +
            " | Layer : " + LayerMask.LayerToName(other.gameObject.layer) +
            " | Rigidbody : " + (other.attachedRigidbody != null)
        );
    }

    private void OnTriggerStay(Collider other)
    {
        if (detectedColliders.Add(other))
        {
            Debug.Log("TRIGGER STAY : " + other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("TRIGGER EXIT : " + other.name);
        detectedColliders.Remove(other);
    }
}
