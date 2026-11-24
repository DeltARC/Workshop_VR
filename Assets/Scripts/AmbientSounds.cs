
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSounds : MonoBehaviour
{
    [Header("List Sounds")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> grabSounds = new List<AudioClip>();

    [Header("Random Interval")]
    [SerializeField] private float minInterval = 15f;
    [SerializeField] private float maxInterval = 40f;

    private void Start()
    {
        StartCoroutine(PlayAmbientSounds());
    }

    private IEnumerator PlayAmbientSounds()
    {
        while (true)
        {
            // Attendre un délai aléatoire
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);

            // Vérifier que la liste contient des sons
            if (grabSounds.Count == 0 || audioSource == null)
                continue;

            // Choisir et jouer un son aléatoire
            AudioClip randomSound = grabSounds[Random.Range(0, grabSounds.Count)];
            audioSource.PlayOneShot(randomSound);
        }
    }
}
