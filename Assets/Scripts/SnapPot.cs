using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SnapPot : MonoBehaviour
{
    [SerializeField] private Transform potPlacement;
    [SerializeField] private MeshRenderer placementRenderer;
    private FlowerPot currentPot;
    private XRGrabInteractable currentGrab;

    private bool isInsideZone = false;
    [SerializeField] private bool isItSunnyHere = false;

    [Header("Placing Sounds")]
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private List<AudioClip> grabSounds = new List<AudioClip>();
    private void OnTriggerEnter(Collider other)
    {
        FlowerPot flowerPot = other.GetComponentInParent<FlowerPot>();

        if (flowerPot == null)
            return;

        currentPot = flowerPot;
        currentGrab = flowerPot.GetComponent<XRGrabInteractable>();

        if (currentGrab == null)
            return;

        isInsideZone = true;

        // Masquer le mesh de l'emplacement
        placementRenderer.enabled = false;

        currentGrab.selectExited.AddListener(OnPotReleased);
    }

    private void OnTriggerExit(Collider other)
    {
        FlowerPot flowerPot = other.GetComponentInParent<FlowerPot>();

        if (flowerPot != currentPot)
            return;

        isInsideZone = false;

        // Réafficher le mesh de l'emplacement
        placementRenderer.enabled = true;

        currentGrab.selectExited.RemoveListener(OnPotReleased);

        currentPot = null;
        currentGrab = null;
    }
    private void OnPotReleased(SelectExitEventArgs args)
    {
        if (!isInsideZone)
            return;

        // On corrige uniquement la position et la rotation
        currentPot.transform.SetPositionAndRotation(
            potPlacement.position,
            potPlacement.rotation
        );

        Debug.Log("Pot aligned !");

        PlayRandomPlacingSound();
    }

    private void PlayRandomPlacingSound()
    {
        if (audioSource == null || grabSounds.Count == 0)
            return;

        AudioClip randomSound = grabSounds[Random.Range(0, grabSounds.Count)];

        audioSource.PlayOneShot(randomSound);
    }
}