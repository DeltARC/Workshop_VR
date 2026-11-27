
using System.Collections;
using UnityEngine;

public class CatPetting : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private TestCatReact testcatReact;

    [Header("Rotation")]
    [SerializeField] private float rotationDuration = 2f;
    [SerializeField] private int rotationCount = 2;

    [Header("Petting Detection")]
    [SerializeField] private float minimumMovement = 0.01f;
    [SerializeField] private float pettingCooldown = 0.5f;

    private Vector3 previousHandPosition;
    private bool hasPreviousPosition;
    private bool isRotating;
    private float lastPettingTime;

    private void OnTriggerStay(Collider other)
    {
        Hands hands = other.GetComponentInParent<Hands>();

        if (hands == null)
            return;

        Vector3 currentPosition = other.transform.position;

        if (!hasPreviousPosition)
        {
            previousHandPosition = currentPosition;
            hasPreviousPosition = true;
            Debug.Log("Main détectée sur le chat : " + other.name);
            return;
        }

        float movement = Vector3.Distance(previousHandPosition, currentPosition);
        previousHandPosition = currentPosition;

        if (movement >= minimumMovement &&
            Time.time >= lastPettingTime + pettingCooldown)
        {
            Debug.Log("CARESSE DU CHAT !");

            lastPettingTime = Time.time;

            if (testcatReact != null)
                testcatReact.StartPetting();

            if (!isRotating)
                StartCoroutine(RotateCat());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Hands hands = other.GetComponentInParent<Hands>();

        if (hands != null)
        {
            hasPreviousPosition = false;
            Debug.Log("Main sortie du chat : " + other.name);
        }
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
