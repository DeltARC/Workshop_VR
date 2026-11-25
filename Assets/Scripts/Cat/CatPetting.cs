
using System.Collections;
using UnityEngine;

public class CatPetting : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pettingSound;
    [SerializeField] private AudioClip specialSound;
    [Range(0f, 1f)]
    [SerializeField] private float specialSoundChance = 0.15f;

    [Header("Rotation")]
    [SerializeField] private float rotationDuration = 2f;
    [SerializeField] private int rotationCount = 2;

    [Header("Petting Detection")]
    [SerializeField] private float minimumMovement = 0.01f;
    [SerializeField] private float pettingCooldown = 0.5f;

    private Vector3 previousHandPosition;
    private bool hasPreviousPosition;
    private bool isPetting;
    private bool isRotating;
    private float lastPettingTime;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Hand"))
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

        if (movement >= minimumMovement)
        {
            Debug.Log("Mouvement détecté : " + movement);

            if (!isPetting && Time.time >= lastPettingTime + pettingCooldown)
            {
                Debug.Log("CARESSE DÉTECTÉE !");
                StartPetting();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            hasPreviousPosition = false;
            Debug.Log("Main sortie du collider du chat : " + other.name);
        }
    }

    private void StartPetting()
    {
        isPetting = true;
        lastPettingTime = Time.time;

        if (audioSource != null && pettingSound != null)
            audioSource.PlayOneShot(pettingSound);
        else
            Debug.LogWarning("AudioSource ou Petting Sound manquant !");

        if (audioSource != null && specialSound != null &&
            Random.value <= specialSoundChance)
        {
            audioSource.PlayOneShot(specialSound);
        }

        if (!isRotating)
            StartCoroutine(RotateCat());

        StartCoroutine(PettingCooldown());
    }

    private IEnumerator PettingCooldown()
    {
        yield return new WaitForSeconds(pettingCooldown);
        isPetting = false;
    }

    private IEnumerator RotateCat()
    {
        isRotating = true;

        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = startRotation *
            Quaternion.Euler(0f, 360f * rotationCount, 0f);

        float elapsedTime = 0f;

        while (elapsedTime < rotationDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / rotationDuration);

            transform.rotation = Quaternion.Slerp(
                startRotation, targetRotation, progress);

            yield return null;
        }

        transform.rotation = targetRotation;
        isRotating = false;
    }
}
