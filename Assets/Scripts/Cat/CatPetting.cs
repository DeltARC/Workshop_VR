
using System.Collections.Generic;
using UnityEngine;

public class CatPetting : MonoBehaviour
{
    private Dictionary<Collider, Vector3> previousPositions = new Dictionary<Collider, Vector3>();

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Hand"))
            return;

        Vector3 currentPosition = other.transform.position;

        if (!previousPositions.ContainsKey(other))
        {
            previousPositions.Add(other, currentPosition);
            Debug.Log("Main détectée : " + other.name);
            return;
        }

        float movement = Vector3.Distance(previousPositions[other], currentPosition);
        previousPositions[other] = currentPosition;

        if (movement > 0.01f)
        {
            Debug.Log("Mouvement de caresse détecté : " + other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        previousPositions.Remove(other);
    }
}
