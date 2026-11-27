
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPetting : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private TestCatReact testCatReact;

    [Header("Rotation")]
    [SerializeField] private float rotationDuration = 2f;
    [SerializeField] private int rotationCount = 2;

    [Header("Petting Detection")]
    [SerializeField] private float minimumMovement = 0.01f;
    [SerializeField] private float pettingCooldown = 0.5f;

    private Dictionary<Collider, Vector3> previousPositions = new Dictionary<Collider, Vector3>();
    private float lastPettingTime;
    private bool isRotating;

    private void Awake()
    {
        if (testCatReact == null)
            testCatReact = GetComponentInChildren<TestCatReact>();
    }

    private bool IsHandOrController(Collider other)
    {
        if (other.GetComponentInParent<Hands>() != null)
            return true;

        Transform current = other.transform;

        while (current != null)
        {
            if (current.CompareTag("Hand"))
                return true;

            current = current.parent;
        }

        return false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!IsHandOrController(other))
            return;

        Vector3 currentPosition = other.transform.position;

        if (!previousPositions.ContainsKey(other))
        {
            previousPositions.Add(other, currentPosition);
            Debug.Log("Main ou manette détectée : " + other.name);
            return;
        }

        float movement = Vector3.Distance(
            previousPositions[other],
            currentPosition
        );

        previousPositions[other] = currentPosition;

        if (movement >= minimumMovement &&
            Time.time >= lastPettingTime + pettingCooldown)
        {
            Debug.Log("CARESSE DU CHAT !");

            lastPettingTime = Time.time;

            if (testCatReact != null)
                testCatReact.StartPetting();
            if (!isRotating)
                StartCoroutine(RotateCat());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        previousPositions.Remove(other);
    }

    private IEnumerator RotateCat()
    {
        isRotating = true;

        float elapsedTime = 0f;
        float totalRotation = 360f * rotationCount;

        while (elapsedTime < rotationDuration)
        {
            float delta = Time.deltaTime;

            transform.Rotate(
                0f,
                totalRotation / rotationDuration * delta,
                0f,
                Space.Self
            );

            elapsedTime += delta;
            yield return null;
        }

        isRotating = false;
    }
}
