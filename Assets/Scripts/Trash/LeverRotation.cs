
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class LeverRotation : MonoBehaviour
{
    [Header("Lever")]
    [SerializeField] private XRLever lever;
    [SerializeField] private float leverInitialAngle = -50f;
    [SerializeField] private float leverActiveAngle = 50f;

    [Header("Object to rotate")]
    [SerializeField] private Transform objectToRotate;
    [SerializeField] private Vector3 rotationAmount = new Vector3(0, 90, 0);

    [Header("Animation")]
    [SerializeField] private float rotationDuration = 2f;
    [SerializeField] private float returnDuration = 2f;

    [Header("Grab Sounds")]
    [SerializeField] private AudioSource audioSource;

    private Quaternion initialObjectRotation;
    private Quaternion initialLeverRotation;
    private Quaternion targetLeverRotation;
    private bool isAnimating;

    private void Awake()
    {
        // Aligner les limites du XRLever sur nos angles
        lever.minAngle = leverInitialAngle;
        lever.maxAngle = leverActiveAngle;
    }

    private void Start()
    {
        initialObjectRotation = objectToRotate.localRotation;
        initialLeverRotation = Quaternion.Euler(leverInitialAngle, 0, 0);
        targetLeverRotation = Quaternion.Euler(leverActiveAngle, 0, 0);
        audioSource = GetComponent<AudioSource>();
        lever.handle.localRotation = initialLeverRotation;
    }

    private void OnEnable()
    {
        lever.onLeverActivate.AddListener(RotateObject);
    }

    private void OnDisable()
    {
        lever.onLeverActivate.RemoveListener(RotateObject);
    }

    private void RotateObject()
    {
        if (!isAnimating)
            StartCoroutine(RotationSequence());
    }

    private IEnumerator RotationSequence()
    {
        isAnimating = true;

        Quaternion targetObjectRotation =
            initialObjectRotation * Quaternion.Euler(rotationAmount);

        // Attendre que le levier atteigne réellement +50°
        while (lever.isSelected &&
               GetHandleAngle() < leverActiveAngle - 1f)
        {
            yield return null;
        }

        // Si le joueur relâche avant d'atteindre +50°
        if (!lever.isSelected)
        {
            lever.value = false;
            isAnimating = false;
            yield break;
        }

        // Animation de l'objet uniquement
        PlayActivationSound();

        yield return AnimateObject(
            initialObjectRotation,
            targetObjectRotation,
            rotationDuration
        );

        // Attendre que le joueur relâche
        while (lever.isSelected)
            yield return null;

        // Animation retour
        PlayActivationSound();

        yield return AnimateBoth(
            targetObjectRotation,
            initialObjectRotation,
            lever.handle.localRotation,
            initialLeverRotation,
            returnDuration
        );

        // Réinitialiser la valeur
        lever.value = false;

        isAnimating = false;
    }

    private float GetHandleAngle()
    {
        return Mathf.DeltaAngle(
            0f,
            lever.handle.localEulerAngles.x
        );
    }

    private IEnumerator AnimateObject(
        Quaternion objectStart,
        Quaternion objectEnd,
        float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / duration);

            objectToRotate.localRotation = Quaternion.Slerp(
                objectStart,
                objectEnd,
                progress
            );

            yield return null;
        }

        objectToRotate.localRotation = objectEnd;
    }

    private IEnumerator AnimateBoth(
        Quaternion objectStart,
        Quaternion objectEnd,
        Quaternion leverStart,
        Quaternion leverEnd,
        float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / duration);

            objectToRotate.localRotation = Quaternion.Slerp(
                objectStart,
                objectEnd,
                progress
            );

            lever.handle.localRotation = Quaternion.Slerp(
                leverStart,
                leverEnd,
                progress
            );

            yield return null;
        }

        objectToRotate.localRotation = objectEnd;
        lever.handle.localRotation = leverEnd;
    }

    private void PlayActivationSound()
    {
        audioSource.Play();
    }
}
