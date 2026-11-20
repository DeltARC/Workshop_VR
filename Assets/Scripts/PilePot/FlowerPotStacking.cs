
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FlowerPotStack : MonoBehaviour
{
    [Header("Pots (du bas vers le haut)")]
    [SerializeField] private List<FlowerPot> pots = new List<FlowerPot>();

    [Header("Grab Sounds")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> grabSounds = new List<AudioClip>();

    private int currentTopIndex;

    private void Start()
    {
        currentTopIndex = pots.Count - 1;

        // Désactiver tous les pots au départ
        for (int i = 0; i < pots.Count; i++)
        {
            XRGrabInteractable grab = pots[i].GetComponent<XRGrabInteractable>();

            if (grab == null)
            {
                Debug.LogError("Un pot ne possède pas de XRGrabInteractable !");
                continue;
            }

            grab.enabled = false;

            FlowerPot capturedPot = pots[i];

            // Détecter la récupération du pot
            grab.selectEntered.AddListener(args =>
            {
                OnPotGrabbed(capturedPot);
                PlayRandomGrabSound();
            });

            // Détecter le relâchement du pot
            grab.selectExited.AddListener(args =>
                StartCoroutine(KeepPhysicsActive(capturedPot))
            );
        }

        // Autoriser uniquement le pot du sommet
        if (currentTopIndex >= 0)
        {
            pots[currentTopIndex].GetComponent<XRGrabInteractable>().enabled = true;
        }
    }

    private void OnPotGrabbed(FlowerPot pot)
    {
        if (currentTopIndex < 0 || pots[currentTopIndex] != pot)
            return;

        // Réactiver la physique du pot récupéré
        Rigidbody rb = pot.GetComponent<Rigidbody>();

        if (rb != null)
            rb.isKinematic = false;

        // Passer au pot suivant
        currentTopIndex--;

        // Autoriser le nouveau pot du sommet
        if (currentTopIndex >= 0)
        {
            pots[currentTopIndex].GetComponent<XRGrabInteractable>().enabled = true;
        }
    }

    private IEnumerator KeepPhysicsActive(FlowerPot pot)
    {
        // Attendre que le XRGrabInteractable termine son traitement
        yield return null;

        Rigidbody rb = pot.GetComponent<Rigidbody>();

        if (rb != null)
            rb.isKinematic = false;
    }

    private void PlayRandomGrabSound()
    {
        if (audioSource == null || grabSounds.Count == 0)
            return;

        AudioClip randomSound = grabSounds[Random.Range(0, grabSounds.Count)];

        audioSource.PlayOneShot(randomSound);
    }
}
