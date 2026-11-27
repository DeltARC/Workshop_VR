
using System.Collections.Generic;
using UnityEngine;

public class CatPetting : MonoBehaviour
{
    [Header("Petting Settings")]
    [SerializeField] private CatFeedback catFeedback;
    [SerializeField] private float movementThreshold = 0.05f;
    [SerializeField] private float reactionInterval = 0.5f;

    private Dictionary<Collider, Vector3> previousPositions = new Dictionary<Collider, Vector3>();
    private float nextReactionTime = 0f;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Hand"))
            return;

        Vector3 currentPosition = other.transform.position;

        if (!previousPositions.ContainsKey(other))
        {
            previousPositions.Add(other, currentPosition);
            return;
        }

        float movement = Vector3.Distance(previousPositions[other], currentPosition);
        previousPositions[other] = currentPosition;

        if (movement > movementThreshold && Time.time >= nextReactionTime)
        {
            catFeedback.StartPetting();
            nextReactionTime = Time.time + reactionInterval;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        previousPositions.Remove(other);
    }
}
